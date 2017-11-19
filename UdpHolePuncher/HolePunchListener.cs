using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UdpHolePuncher
{
    /// <summary>
    /// listens for the hole punch connections
    /// </summary>
    public abstract class HolePunchListener
    {

        /// <summary>
        /// port to listen on
        /// </summary>
        public int Port { get; protected set; }
        /// <summary>
        /// creates a listener on the given port with the given handler
        /// </summary>
        /// <param name="port">the port for it to listen on</param>
        protected HolePunchListener(int port)
        {
            Port = port;
        }

        /// <summary>
        /// has it listen on configured port
        /// </summary>
        /// <returns>void</returns>
        public async Task Listen()
        {
            await Listen(CancellationToken.None);
        }

        /// <summary>
        /// has it listen on configured port
        /// </summary>
        /// <param name="token">the cancellation token</param>
        /// <returns>void</returns>
        public virtual async Task Listen(CancellationToken token)
        {
            var listener = new UdpClient(Port);
            while (true)
            {
                var received = await listener.ReceiveAsync();
                HandleReceived(received);
            }
        }

        /// <summary>
        /// handles the received packet
        /// </summary>
        /// <param name="toHandle">the packet to handle</param>
        /// <returns>void</returns>
        public async Task HandleReceived(UdpReceiveResult toHandle)
        {
            await Task.Yield();
        }
    }
}
