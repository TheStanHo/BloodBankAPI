using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using BloodBankAPI.Models;

namespace BloodBankAPI.Data
{
    public class DataClass
    {

        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<BloodBankContext>();
                context.Database.EnsureCreated();
                if (context.BloodDB != null)
                {
                    return;
                }

              
                
            }

          
        }
    }
}
