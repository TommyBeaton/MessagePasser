using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagePasser
{
    public class SubscriberManager : ISubscriberManager
    {
        private List<SubscriberModel> _mainThreadSubscribers = new List<SubscriberModel>();
        private List<SubscriberModel> _backgroundThreadSubscribers = new List<SubscriberModel>();

        public List<SubscriberModel> MainThreadSubscribers { get { return _mainThreadSubscribers; } }
        public List<SubscriberModel> BackgroundThreadSubscribers { get { return _backgroundThreadSubscribers; } }

        private List<Type> GetAllTypesOfMessageHandler<T>(T subscriber)
        {
            return subscriber.GetType().GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMessageHandler<>))
                .SelectMany(i => i.GetGenericArguments())
                .ToList();
        }

        private bool AddSubscriber<T>(ref List<SubscriberModel> subscriberList, List<Type> interests, T subscriber)
        {
            bool status = false;

            if (interests.Count > 0)
            {
                status = true;

                subscriberList.Add(new SubscriberModel
                {
                    Interests = interests,
                    SubscribedObject = subscriber
                });
            }

            return status;
        }

        private bool ValidateNewSubscriber<T>(T subscriber, ref List<SubscriberModel> subscriberList)
        {
            if(subscriber == null)
                return false;

            var matchCount = subscriberList.Where(x => x.SubscribedObject == (object)subscriber).Count();

            if (matchCount > 0)
                return false;

            return true;
        }

        private bool HandleSubscriptionRequest<T>(T subscriber, ref List<SubscriberModel> subscriptionList)
        {
            bool subscribeStatus = false;

            subscribeStatus = ValidateNewSubscriber(subscriber, ref _backgroundThreadSubscribers);

            var interests = GetAllTypesOfMessageHandler(subscriber);

            subscribeStatus = AddSubscriber(ref _backgroundThreadSubscribers, interests, subscriber);

            return subscribeStatus;
        }

        public bool SubscribeOnBackgroundThread<T>(T subscriber)
        {
            return HandleSubscriptionRequest(subscriber, ref _backgroundThreadSubscribers);
        }

        public bool SubscribeOnMainThread<T>(T subscriber)
        {
            return HandleSubscriptionRequest(subscriber, ref _mainThreadSubscribers);
        }

        public void Unsubscribe<T>(T subscriber)
        {
            throw new NotImplementedException();
        }

        public void UnsubscribeOnBackgroundThread<T>(T subscriber)
        {
            throw new NotImplementedException();
        }

        public void UnsubscribeOnMainThread<T>(T subscriber)
        {
            throw new NotImplementedException();
        }
    }
}
