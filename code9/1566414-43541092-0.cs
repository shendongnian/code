    class Program
    {
        static void Main(string[] args)
        {
            var basePath = GetDotNetCoreBasePath();
            Console.WriteLine();
            Console.ReadLine();
        }
        static String GetDotNetCoreBasePath()
        {
            Process process = new Process
            {
                StartInfo =
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    FileName = "dotnet",
                    Arguments = "--info"
                }
            };
            process.Start();
            process.WaitForExit();
            if (process.HasExited)
            {
                string output = process.StandardOutput.ReadToEnd();
                if (String.IsNullOrEmpty(output) == false)
                {
                    var reg = new Regex("Base Path:(.+)");
                    var matches = reg.Match(output);
                    if (matches.Groups.Count >= 2)
                        return matches.Groups[1].Value.Trim();
                }
            }
            throw new Exception("DotNet Core Base Path not found.");
        }
    }
