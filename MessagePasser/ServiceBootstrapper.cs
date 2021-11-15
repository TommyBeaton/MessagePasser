using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagePasser
{
    public static class ServiceBootstrapper
    {

        public static IServiceProvider GetServiceProvider()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<ISubscriberManager, SubscriberManager>();
            serviceCollection.AddSingleton<IMessageManager , MessageManager>();

            //serviceCollection.AddSingleton<ISubscriberManager, SubscriberManager>

            return serviceCollection.BuildServiceProvider();
        }
    }
}
