using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5EntityTest.EFConfiguration
{
    public class EntityFrameworkConfigurationProvider : ConfigurationProvider
    {
        public EntityFrameworkConfigurationProvider(Action<DbContextOptionsBuilder> optionsAction)
        {
            OptionsAction = optionsAction;
        }

        public Action<DbContextOptionsBuilder> OptionsAction { get;  }

        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<ConfigurationDbContext>();
            OptionsAction(builder);

            using (var dbContext = new ConfigurationDbContext(builder.Options))
            {
                dbContext.Database.EnsureCreated();
                
                try
                {
                    //exception if the tabhle is not created yet
                    if (!dbContext.ConfigurationValues.Any())
                        Data = CreateAndSaveDefaultValues(dbContext);
                    else
                        Data = dbContext.ConfigurationValues.ToDictionary(x => x.Key, x => x.Value);
                }
                catch { }
            }
        }

        private IDictionary<string, string> CreateAndSaveDefaultValues(ConfigurationDbContext dbContext)
        {
            var configValues = new Dictionary<string, string>
            {
                { "Title", "Title From DB"},
                { "ShowInRed", "True"}
            };

            dbContext.ConfigurationValues.AddRange(configValues
                .Select(kvp => new ConfigurationValue { Key = kvp.Key, Value = kvp.Value })
                .ToArray());

            dbContext.SaveChanges();
            return configValues;
        }
    }
}
