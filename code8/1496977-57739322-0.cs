    /// <summary>
    /// Run wevtutil with the given parameters.
    /// </summary>
    /// <param name="programPath">Path to wevtutil</param>
    /// <param name="programParameters">wevutil parameters</param>
    /// <returns></returns>
    /// <remarks>https://stackoverflow.com/a/37138255/468523</remarks>
    private static (string info, string err) RunWevtUtil(string programPath, string programParameters)
    {
        var process = new Process
        {
            StartInfo =
            {
                FileName = programPath,
                Arguments = programParameters,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            }
        };
        process.Start();
        var outputData = process.StandardOutput.ReadToEnd();
        var errorData = process.StandardError.ReadToEnd();
        process.WaitForExit();
        return (outputData, errorData);
    }
