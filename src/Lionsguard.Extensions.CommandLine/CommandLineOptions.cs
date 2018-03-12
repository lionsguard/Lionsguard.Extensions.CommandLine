using System;
using System.Collections.Generic;

namespace Lionsguard.Extensions.CommandLine
{
    public class CommandLineOptions
    {
        public Dictionary<string, Func<CommandSpec,ICommand>> CommandFactories { get; } = new Dictionary<string, Func<CommandSpec,ICommand>>(StringComparer.InvariantCultureIgnoreCase);
    }
}
