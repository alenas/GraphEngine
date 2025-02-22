// Graph Engine
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Trinity.Lib
{
    class AssemblyHelper
    {
        internal static void JitClass(Type type)
        {
            var methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            foreach (var method in methods)
            {
                RuntimeHelpers.PrepareMethod(method.MethodHandle);
            }
        }
    }
}
