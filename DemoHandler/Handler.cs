using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePasser;
using MessagePasser.Interfaces;

namespace DemoHandler
{
    public class Handler : IMessageHandler<string>
    {
        private EventAggregator _aggregator;

        public Handler(EventAggregator aggregator)
        {
            _aggregator = aggregator;
            _aggregator.Subscribe(this);
        }

        public void HandleMessage(string message)
        {
            Console.WriteLine("Handling message: " + message);
            Console.WriteLine("Blah blah blah");
        }

        public void SendMessage(string message)
        {
            Console.WriteLine("Handler sending message: " + message);

            _aggregator.SendMessage(message);
        }
    }
}
