using Business.Managers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnackMachine
{
    public class Services
    {
        public static void Run()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IInventoryManager, InventoryManager>();
            services.AddSingleton<SnackMachineManager>();
            var serviceProvider = services.BuildServiceProvider();
            var snackMachine = serviceProvider.GetService<SnackMachineManager>();
            snackMachine.DisplaySnacks();
        }
    }
}
