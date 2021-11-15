﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagePasser
{
    public interface IMessageHandler<T>
    {
        public Task HandleMessage(T message, CancellationToken token);
    }
}
