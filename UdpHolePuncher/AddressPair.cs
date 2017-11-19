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

        /// <summary>
        /// checks whether this pair matches by ip another pair
        /// </summary>
        /// <param name="pair">the pair to check</param>
        /// <returns>true if the ips match, false otherwise</returns>
        public bool IpEquals(AddressPair pair)
        {
            if (PublicIp == null || PrivateIp == null || pair.PrivateIp == null || pair.PublicIp == null)
            {
                return false;
            }
            return PublicIp.Address.Equals(pair.PublicIp.Address) && PrivateIp.Address.Equals(pair.PrivateIp.Address);
        }
    }
}
