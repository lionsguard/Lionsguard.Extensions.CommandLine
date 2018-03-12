using Lionsguard.Extensions.CommandLine;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddCommandLine(this IServiceCollection services, Action<CommandLineOptions> configureOptions = null)
        {
            services.AddOptions();
            
            services.AddSingleton<ICommandFactory, CommandFactory>();

            if (configureOptions != null)
                services.Configure(configureOptions);

            return services;
        }
    }
}
