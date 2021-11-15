using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagePasser
{
    public class SubscriberModel
    {
        public object SubscribedObject { get; set; }
        public List<Type> Interests { get; set; }
    }
}
