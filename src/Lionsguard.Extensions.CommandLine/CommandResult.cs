namespace Lionsguard.Extensions.CommandLine
{
    public struct CommandResult
    {
        public bool IsSuccess;
        public int ExitCode;
        public string Message;

        public CommandResult(bool isSuccess, int exitCode, string message)
        {
            IsSuccess = isSuccess;
            ExitCode = exitCode;
            Message = message;
        }

        public static CommandResult Success()
        {
            return new CommandResult(true, 0, string.Empty);
        }

        public static CommandResult Fail(int exitCode, string message)
        {
            return new CommandResult(false, exitCode, message);
        }
    }
}
