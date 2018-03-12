using System;
using System.Collections.Generic;
using System.Linq;

namespace Lionsguard.Extensions.CommandLine
{
    public class CommandSpec
    {
        public string Command { get; set; }
        public IDictionary<string, string> Args { get; } = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

        public CommandSpec(string command, params KeyValuePair<string,string>[] args)
        {
            Command = command;
            foreach (var kvp in args)
            {
                Args[kvp.Key] = kvp.Value;
            }
        }

        public CommandSpec(string[] args)
        {
            if (args == null || args.Length == 0)
                throw new ArgumentNullException(nameof(args));

            Command = args.ElementAtOrDefault(0);
            var key = string.Empty;
            var value = new List<string>();
            var isParsingQuotedText = false;
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("--") || args[i].StartsWith("-"))
                {
                    if (!string.IsNullOrEmpty(key))
                    {
                        Args[key] = string.Empty;
                        key = null;
                    }

                    key = args[i].Replace("-", string.Empty);
                    continue;
                }

                // Value
                if (!string.IsNullOrEmpty(key))
                {
                    if (args[i].StartsWith("\"") || args[i].EndsWith("\""))
                    {
                        isParsingQuotedText = !isParsingQuotedText;
                        if (!isParsingQuotedText)
                        {
                            // end quoting
                            value.Add(args[i]);
                            Args[key] = string.Join(" ", value);
                            key = null;
                            continue;
                        }
                    }
                    
                    if (isParsingQuotedText)
                    {
                        value.Add(args[i]);
                        continue;
                    }

                    Args[key] = args[i];
                    key = null;
                }
            }
        }
    }
}
