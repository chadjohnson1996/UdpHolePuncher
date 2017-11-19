using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
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

        private ConcurrentDictionary<IPEndPoint, IConnectionHandler> Connections { get; } = new ConcurrentDictionary<IPEndPoint, IConnectionHandler>();
        /// <summary>
        /// port to listen on
        /// </summary>
        public int Port { get; protected set; }

        /// <summary>
        /// the handler factory
        /// </summary>
        public Func<IPEndPoint, IConnectionHandler> HandlerFactory { get; protected set; }
        /// <summary>
        /// creates a listener on the given port with the given handler
        /// </summary>
        /// <param name="port">the port for it to listen on</param>
        protected HolePunchListener(int port, Func<IPEndPoint, IConnectionHandler> handlerFactory)
        {
            Port = port;
            HandlerFactory = handlerFactory;
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

            var endpoint = toHandle.RemoteEndPoint;

            if (!Connections.ContainsKey(endpoint))
            {
                Connections[endpoint] = HandlerFactory(endpoint);
            }

            var handler = Connections[endpoint];


            if (handler.Finished)
            {
                Connections.TryRemove(endpoint, out handler);
            }
        }
    }
}
