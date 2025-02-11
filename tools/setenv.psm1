Function Init-Configuration {
    $Global:REPO_ROOT     = [System.IO.Path]::GetFullPath("$PSScriptRoot\..")

    $Global:TRINITY_CMAKELISTS            = "$REPO_ROOT\CMakeLists.txt"
    $Global:TRINITY_OUTPUT_DIR            = "$REPO_ROOT\bin"
    $Global:TRINITY_TEST_DIR              = "$REPO_ROOT\tests"
    $Global:TOOLS_DIR                     = "$REPO_ROOT\tools"
    $Global:NUGET_EXE                     = "nuget.exe"
    # CMAKE is included with VS 2022
    $Global:CMAKE_EXE                     = "cmake.exe"

    $global:ProgressPreference = "SilentlyContinue"

    # Check NuGet
    $command = Get-Command $NUGET_EXE -ErrorAction SilentlyContinue
    if ($command) {
        $Global:NUGET_EXE = $command.Source
        Write-Output "Nuget found at: $($NUGET_EXE)"
    } else {
        Write-Output "Installing NuGet package manager."
        Invoke-Expression "winget install Microsoft.NuGet"
	Write-Output "NuGet installed - restart build..."
	exit 1
    }

    # Check CMAKE
    $command = Get-Command CMAKE_EXE -ErrorAction SilentlyContinue
    if ($command) {
        $Global:CMAKE_EXE = $command.Source
        Write-Output "CMake found at: $($CMAKE_EXE)"
    } else {
        # default VS path
        $command = Get-Command "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\CommonExtensions\Microsoft\CMake\CMake\bin\$($CMAKE_EXE)" -ErrorAction SilentlyContinue
        if ($command) {
            $Global:CMAKE_EXE = $command.Source
            Write-Output "CMake found at: $($CMAKE_EXE)"
        } else {
            Write-Output "CMake is not on path!"
            Write-Output "Use Developer PowerShell to execute build.ps1 or add cmake to path."
            exit 1
        }
    }

    New-Item -Path "$TRINITY_OUTPUT_DIR" -ItemType Directory -ErrorAction SilentlyContinue
}

Function Write-Configuration {
  Write-Output "GraphEngine repo root:         $REPO_ROOT"
  Write-Output "TRINITY_CMAKELISTS             $TRINITY_CMAKELISTS"
  Write-Output "TRINITY_OUTPUT_DIR:            $TRINITY_OUTPUT_DIR"
}


Function Remove-And-Print ($item) {
  if ($item -eq $null) { return }
  Write-Output "[x] Removing: $item"
  Remove-Item -Recurse -Force -ErrorAction Ignore -Path $item
}

Function Remove-Build {
  Remove-And-Print "$REPO_ROOT\bin"
  Remove-And-Print "$REPO_ROOT\build"
}

# Register local nuget source
# calling `nuget sources list` will create the config file if it does not exist
Function Register-LocalRepo {
  Invoke-Expression "& '$NUGET_EXE' sources list"
  Invoke-Expression "& '$NUGET_EXE' sources Remove -Name 'Graph Engine OSS Local'"
  Invoke-Expression "& '$NUGET_EXE' sources Add -Name 'Graph Engine OSS Local' -Source '$TRINITY_OUTPUT_DIR'"
}

Function Restore-GitSubmodules {
    Invoke-Expression "git submodule init" -ErrorAction Stop
    Invoke-Expression "git submodule update --recursive" -ErrorAction Stop
}

Init-Configuration
Export-ModuleMember -Variable *
Export-ModuleMember -Function *
