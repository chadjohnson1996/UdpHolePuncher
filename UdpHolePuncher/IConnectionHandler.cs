using System;
using System.Collections.Generic;
using System.Text;

namespace UdpHolePuncher
{
    public interface IConnectionHandler
    {
        /// <summary>
        /// whether or not it is done
        /// </summary>
        bool Finished { get; set; }

        /// <summary>
        /// the connection type
        /// </summary>
        ConnectionTypeEnum Type { get; set; }
    }
}
