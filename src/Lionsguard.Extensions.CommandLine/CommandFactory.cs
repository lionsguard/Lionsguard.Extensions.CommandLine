using Microsoft.Extensions.Options;

namespace Lionsguard.Extensions.CommandLine
{
    public class CommandFactory : ICommandFactory
    {
        readonly CommandLineOptions _options;
        public CommandFactory(IOptions<CommandLineOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        public CommandResult Execute(string[] args)
        {
            var spec = new CommandSpec(args);

            if (!_options.CommandFactories.TryGetValue(spec.Command, out var factory))
                return CommandResult.Fail(ErrorCodes.CommandFactoryNotFound, string.Format("A factory method cou;d not be found for the command '{0}'.", spec.Command));

            var cmd = factory.Invoke(spec);
            if (cmd == null)
                return CommandResult.Fail(ErrorCodes.CommandNotFound, string.Format("Command factory returned an null ICommand instance for verb '{0}'", spec.Command));

            return cmd.Execute(spec.Args);
        }
    }
}
