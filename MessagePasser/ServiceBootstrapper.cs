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
        public static IServiceCollection BuildUp()
        {
            IServiceCollection serviceCollection = new ServiceCollection();


            return serviceCollection;
        }
    }
}
