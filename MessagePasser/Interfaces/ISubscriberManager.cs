using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagePasser
{
    public interface ISubscriberManager
    { 

        public List<SubscriberModel> MainThreadSubscribers { get; }
        public List<SubscriberModel> BackgroundThreadSubscribers { get; }


        /// <summary>
        /// Register an instance of a class to the event aggregator so it can start recieving messages.
        /// </summary>
        /// <typeparam name="T">Any instance of a class that you want as your subscriber</typeparam>
        /// <param name="subscriber">The instance that you want to recieve messages through. This class should impliment IMessageHandler<> to recieve messages.</param>
        /// <returns>Returns true if the aggregator was able to find at least one instance of IMessageHandler<> and could add it as a subscriber. Returns false if it wasn't implimented or an error occured.</returns>
        /// <exception cref="NullReferenceException">As T is being used, if null is passed this exception will be raised.</exception>
        public bool SubscribeOnMainThread<T>(T subscriber);
        public bool SubscribeOnBackgroundThread<T>(T subscriber);

        public void UnsubscribeOnMainThread<T>(T subscriber);
        public void UnsubscribeOnBackgroundThread<T>(T subscriber);
        public void Unsubscribe<T>(T subscriber);
    }
}
