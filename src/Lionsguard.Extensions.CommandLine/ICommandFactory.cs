namespace Lionsguard.Extensions.CommandLine
{
    public interface ICommandFactory
    {
        CommandResult Execute(string[] args);
    }
}
