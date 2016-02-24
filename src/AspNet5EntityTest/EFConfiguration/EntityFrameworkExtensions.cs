using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5EntityTest.EFConfiguration
{
    public static class EntityFrameworkExtensions
    {
        public static IConfigurationBuilder AddEntityFramework(this IConfigurationBuilder builder, Action<DbContextOptionsBuilder> setup)
        {
            return builder.Add(new EntityFrameworkConfigurationProvider(setup));
        }
    }
}
