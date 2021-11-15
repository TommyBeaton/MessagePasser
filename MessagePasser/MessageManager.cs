using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MessagePasser.Delegates.Delegates;

namespace MessagePasser
{
    public class MessageManager : IMessageManager
    {
        private readonly ISubscriberManager _subscriberManager;

        public MessageManager(ISubscriberManager subscriberManager)
        {
            _subscriberManager = subscriberManager;
        }

        private void SendMessage<T>(T message, CancellationToken token, List<SubscriberModel> subscriberList, OnMessageSent callback = null)
        {
            if(message == null)
                throw new NullReferenceException();

            int subscriberCount = 0;

            for (int i = 0; i < subscriberList.Count; i++)
            {
                foreach (var interest in subscriberList[i].Interests)
                {
                    if (interest == message.GetType())
                    {
                        subscriberCount++;

                        IMessageHandler<T> tempObject = (IMessageHandler<T>)subscriberList[i].SubscribedObject;
                        tempObject.HandleMessage(message, token);
                    }
                }
            }

            if (callback != null)
            {
                callback.Invoke(subscriberCount);
            }
        }

        public void SendMessageOnBackgroundThread<T>(T message, CancellationToken token, OnMessageSent callback = null)
        {
            Task.Run(() => SendMessage(message, CancellationToken.None, _subscriberManager.BackgroundThreadSubscribers, callback));
        }

        public void SendMessageOnMainThread<T>(T message, CancellationToken token, OnMessageSent callback = null)
        {
            SendMessage<T>(message, CancellationToken.None, _subscriberManager.MainThreadSubscribers, callback);
        }
    }
}
