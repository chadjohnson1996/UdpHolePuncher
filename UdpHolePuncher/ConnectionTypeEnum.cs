using System;
using System.Collections.Generic;
using System.Text;

namespace UdpHolePuncher
{
    /// <summary>
    /// the different connection types
    /// </summary>
    public enum ConnectionTypeEnum
    {
        /// <summary>
        /// connection that is expilictly requesting a bridge
        /// </summary>
        BridgeRequest,
        /// <summary>
        /// static connection for keepalives and forwarding requests to bridge, etc
        /// </summary>
        StaticConnection
    }
}
