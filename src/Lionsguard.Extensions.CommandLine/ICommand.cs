using System.Collections.Generic;

namespace Lionsguard.Extensions.CommandLine
{
    public interface ICommand
    {
        CommandResult Execute(IDictionary<string,string> args);
    }
}
