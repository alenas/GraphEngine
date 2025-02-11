// Graph Engine
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//
using System;
using System.Runtime.CompilerServices;

namespace Trinity.Storage
{
    public unsafe partial class LocalMemoryStorage : IStorage, IDisposable
    {
        /// <summary>
        /// Get the Memory Trunk Id for the specified 64-bit cell Id.
        /// </summary>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <returns>The Id of the memory trunk that stores the cell with the specified Id.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetTrunkId(long cellId)
        {
            return *(byte*)&cellId;
        }
    }
}
