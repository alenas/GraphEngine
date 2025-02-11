// Graph Engine
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//
namespace Trinity.Network
{
    /// <summary>
    /// Represents a stock Trinity proxy.
    /// </summary>
    public class TrinityProxy : CommunicationInstance
    {
        /// <inheritdoc/>
        protected internal sealed override RunningMode RunningMode
        {
            get { return Trinity.RunningMode.Proxy; }
        }
    }
}
