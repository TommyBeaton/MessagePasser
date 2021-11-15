using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePasser;
using MessagePasser;

namespace DemoHandler
{
    public class Handler : IMessageHandler<string>
    {
        private EventAggregator _aggregator;

        public Handler(EventAggregator aggregator)
        {
            _aggregator = aggregator;
            _aggregator.SubscribeOnMainThread(this);
        }

        public Task HandleMessage(string message, CancellationToken token)
        {
            Console.WriteLine("Handling message: " + message);
            

            return Task.CompletedTask;
        }

        public void SendMessage(string message)
        {
            Console.WriteLine("Handler sending message: " + message);

            _aggregator.SendMessage(message);
        }
    }
}
