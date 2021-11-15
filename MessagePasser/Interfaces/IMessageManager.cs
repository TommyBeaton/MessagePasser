using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MessagePasser.Delegates.Delegates;

namespace MessagePasser
{
    public interface IMessageManager
    {
        /// <summary>
        /// Sends messages on the main thread to all subscribers of the type.
        /// </summary>
        /// <typeparam name="T">The data type you want to be picked up by the specific message handlers.</typeparam>
        /// <param name="message">The message you want to send to any subscribers of the type.</param>
        /// <param name="token">A cancellation token to be picked up by the message handlers.</param>
        /// <param name="callback">If you want insight into the message then you can make use of the callback. Null by default.</param>
        public void SendMessageOnMainThread<T>(T message, CancellationToken token, OnMessageSent callback = null);

        /// <summary>
        /// Sends messages on a background thread to all subscribers of the type.
        /// </summary>
        /// <typeparam name="T">The data type you want to be picked up by the specific message handlers.</typeparam>
        /// <param name="message">The message you want to send to any subscribers of the type.</param>
        /// <param name="token">A cancellation token to be picked up by the message handlers.</param>
        /// <param name="callback">If you want insight into the message then you can make use of the callback. Null by default.</param>
        public void SendMessageOnBackgroundThread<T>(T message, CancellationToken token, OnMessageSent callback = null);
    }
}
