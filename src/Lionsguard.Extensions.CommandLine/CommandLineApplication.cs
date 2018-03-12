using Microsoft.Extensions.DependencyInjection;
using System;

namespace Lionsguard.Extensions.CommandLine
{
    public static class CommandLineApplication
    {
        public static int Run(string[] args, Action<CommandLineOptions> configureOptions = null)
        {
            try
            {
                var services = new ServiceCollection()
                    .AddCommandLine(configureOptions);

                var provider = services.BuildServiceProvider();

                var factory = provider.GetService<ICommandFactory>();

                var result = factory.Execute(args);
                if (!result.IsSuccess)
                {
                    Console.Error.WriteLine(result.Message);
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                }

                return result.ExitCode;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return ErrorCodes.UnhandledException;
            }
        }
    }
}
