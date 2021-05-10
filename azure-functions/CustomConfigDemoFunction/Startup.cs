using System;
using System.IO;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

[assembly: FunctionsStartup(typeof(CustomConfigDemoFunction.Startup))]

namespace CustomConfigDemoFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

        }
        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            FunctionsHostBuilderContext context = builder.GetContext();

            String environmentSettings = System.Environment.GetEnvironmentVariable("environment_settings", EnvironmentVariableTarget.Process);

            builder.ConfigurationBuilder
                .AddJsonFile(Path.Combine(context.ApplicationRootPath, $"settings.{environmentSettings}.json"), optional: true, reloadOnChange: false)
                .AddEnvironmentVariables();
        }
    }
}