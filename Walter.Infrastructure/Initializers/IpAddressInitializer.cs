using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walter.Core.Entities.Site;

namespace Walter.Infrastructure.Initializers
{
    internal static class IpAddressInitializer
    {
        public static void SeedIp(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IpAddress>().HasData(new IpAddress[]
            {
                new IpAddress() { Id = 1, Address = "0.0.0.0"}
            });
        }
    }
}
