using Microsoft.Extensions.Configuration;
using System;

namespace Services
{
    public static class RecipesServiceFactory
    {
        public static RecipesService Instance { get; set; }

        static RecipesServiceFactory()
        {
            IConfigurationRoot _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var className = _configuration["ClassName"];
            var assemblyName = _configuration["AssemblyName"];

            if (className != null && assemblyName != null)
                Instance = Activator.CreateInstance(assemblyName, className).Unwrap() as RecipesService;
        }
    }
}
