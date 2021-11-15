using MessagePasser.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;

namespace MessagePasser
{
    public class EventAggregator
    {
        class Subscriber
        {
            public object SubscribedObject { get; set; }
            public List<Type> Interests { get; set; }
        }
        
        public static IServiceCollection ServiceCollection;

        private List<Subscriber> _subscribers = new List<Subscriber>();

        public EventAggregator()
        {
            SetUpServiceCollection();
        }

        public void SetUpServiceCollection()
        {
            ServiceCollection = ServiceBootstrapper.BuildUp();
        }

        ///<summary>
        ///</summary>
        public void Subscribe<T>(T subscriber)
        {
            if(subscriber == null)
                throw new NullReferenceException();

            var interests = subscriber.GetType().GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMessageHandler<>))
                .SelectMany(i => i.GetGenericArguments())
                .ToList();

            if(interests.Count > 0)
            {
                _subscribers.Add(new Subscriber
                {
                    Interests = interests,
                    SubscribedObject = subscriber
                });
            }

            foreach(var interest in interests)
            {
                Console.WriteLine("Aggregator added new class: " + interest.Name);
            }
        }

        private void SendMessageOnObject<T>(T message, ref object subscriber)
        {
            IMessageHandler<T> blah = (IMessageHandler<T>)subscriber;
            blah.HandleMessage(message);
        }

        public void SendMessage<T>(T message)
        {
            Console.WriteLine("Sending new message");
            
            for(int i = 0; i < _subscribers.Count; i++)
            {
                foreach (var interest in _subscribers[i].Interests)
                {
                    if (interest == message.GetType())
                    {
                        Console.WriteLine("Found a subscriber, sending message!");
                        object subscriber = _subscribers[i].SubscribedObject;
                        SendMessageOnObject(message, ref subscriber);
                    }
                }
            }
        }
    }
}