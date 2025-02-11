// Graph Engine
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//
using System;

namespace Trinity.Core.Lib
{
    class RandomFactory
    {
        static RandomFactory()
        {
            Random = new XRandom(Environment.TickCount);
        }

        internal static XRandom Random;
    }
}
