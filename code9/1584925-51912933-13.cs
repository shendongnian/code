    static class LinuxClipboard
    {
        public static void SetText(string text)
        {
            var tempFileName = Path.GetTempFileName();
            File.WriteAllText(tempFileName, text);
            try
            {
                BashRunner.Run($"cat {tempFileName} | xclip");
            }
            finally
            {
                File.Delete(tempFileName);
            }
        }
        public static string GetText()
        {
            var tempFileName = Path.GetTempFileName();
            try
            {
                BashRunner.Run($"xclip -o > {tempFileName}");
                return File.ReadAllText(tempFileName);
            }
            finally
            {
                File.Delete(tempFileName);
            }
        }
    }
    static class BashRunner
    {
        public static string Run(string commandLine)
        {
            var errorBuilder = new StringBuilder();
            var outputBuilder = new StringBuilder();
            var arguments = $"-c \"{commandLine}\"";
            using (var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "bash",
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = false,
                }
            })
            {
                process.Start();
                process.OutputDataReceived += (sender, args) => { outputBuilder.AppendLine(args.Data); };
                process.BeginOutputReadLine();
                process.ErrorDataReceived += (sender, args) => { errorBuilder.AppendLine(args.Data); };
                process.BeginErrorReadLine();
                if (!process.WaitForExit(500))
                {
                    var timeoutError = $@"Process timed out. Command line: bash {arguments}.
    Output: {outputBuilder}
    Error: {errorBuilder}";
                    throw new Exception(timeoutError);
                }
                if (process.ExitCode == 0)
                {
                    return outputBuilder.ToString();
                }
                var error = $@"Could not execute process. Command line: bash {arguments}.
    Output: {outputBuilder}
    Error: {errorBuilder}";
                throw new Exception(error);
            }
        }
    }
