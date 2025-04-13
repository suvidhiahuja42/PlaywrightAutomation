using Microsoft.Extensions.DependencyInjection;
using Reqnroll.Microsoft.Extensions.DependencyInjection;
using SauceDemoAutomation.Pages;
using TechTalk.SpecFlow;

namespace SauceDemoAutomation.Support
{
    public static class DependencyInjection
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();

            // Register ScenarioContext
            services.AddSingleton<ScenarioContext>();

            // Register page classes
            services.AddScoped<LoginPage>();

            return services;
        }
    }
}