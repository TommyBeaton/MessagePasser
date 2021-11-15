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
        public void SendMessageOnMainThread<T>(T message, CancellationToken token, OnMessageSent callback = null);
        public void SendMessageOnBackgroundThread<T>(T message, CancellationToken token, OnMessageSent callback = null);
    }
}
