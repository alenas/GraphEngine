// Graph Engine
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//
using Trinity.Extension;

namespace Trinity.Network
{
    /// <summary>
    /// Represents a stock Trinity server.
    /// </summary>
    [ExtensionPriority(-100)]
    public class TrinityServer : CommunicationInstance
    {
        /// <inheritdoc/>
        protected internal sealed override RunningMode RunningMode
        {
            get { return RunningMode.Server; }
        }

    }
}
