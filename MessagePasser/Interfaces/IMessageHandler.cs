using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagePasser
{
    public interface IMessageHandler<T>
    {
        /// <summary>
        /// This will be picked up by the event aggregator to recieve messages of type T
        /// </summary>
        /// <param name="message">The received message.</param>
        /// <param name="token">A cancellation token that can be send from the class that publishes the message.</param>
        /// <returns>A task.</returns>
        public Task HandleMessage(T message, CancellationToken token);
    }
}
