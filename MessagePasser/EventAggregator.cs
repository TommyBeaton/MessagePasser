using MessagePasser;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;
using static MessagePasser.Delegates.Delegates;

namespace MessagePasser
{
    public class EventAggregator
    {
        
        private static IServiceProvider _serviceProvider;
        private ISubscriberManager _subscriberManager;
        private IMessageManager _messageManager;

        public EventAggregator()
        {
            SetUpServiceCollection();
            _subscriberManager = _serviceProvider.GetService<ISubscriberManager>();
            _messageManager = _serviceProvider.GetService<IMessageManager>();
        }

        public void SetUpServiceCollection()
        {
            _serviceProvider = ServiceBootstrapper.GetServiceProvider();
        }

        public bool SubscribeOnMainThread<T>(T subscriber)
        {
            return _subscriberManager.SubscribeOnMainThread(subscriber);
        }

        public bool SubscribeOnBackgroundThread<T>(T subscriber)
        {
            return _subscriberManager.SubscribeOnBackgroundThread(subscriber);
        }

        /// <summary>
        /// Send a message using a specific type. This will call handle message on all classes that have subscribed with this type.
        /// </summary>
        /// <typeparam name="T">The type of message you want to subscribe to</typeparam>
        /// <param name="message">The contents of your message that you want to publish</param>
        /// <param name="callback">Callback if you want insight into the message being sent. Null by default.</param>
        public void SendMessage<T>(T message, OnMessageSent callback = null)
        {
            
        }
    }
}