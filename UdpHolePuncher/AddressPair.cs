using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace UdpHolePuncher
{
    public class AddressPair
    {
        /// <summary>
        /// the public ip 
        /// </summary>
        public IPEndPoint PublicIp { get; set; }
        
        /// <summary>
        /// the private ip
        /// </summary>
        public IPEndPoint PrivateIp { get; set; }
    }
}
