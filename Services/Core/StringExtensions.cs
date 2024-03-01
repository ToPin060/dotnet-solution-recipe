using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Core
{
    public static class StringExtensions
    {
        private static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        public static String GetValue(this String value)
        {
            if (config[value] == null)
                throw new InvalidOperationException();

            return config[value];
        }

        public static String GetConnectionString(this String value)
        {
            if (config.GetConnectionString(value) == null)
                throw new InvalidOperationException();

            return config.GetConnectionString(value);
        }
    }
}
