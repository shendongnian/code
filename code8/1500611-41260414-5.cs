    class Program
    {
        public static void Main()
        {
            Console.WriteLine($"TEST #1: {LaunchProcessAndGetAbsolutePath()}");
            Console.WriteLine($"TEST #2: {LaunchProcessAndGetAbsolutePath(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))}");
            Console.ReadLine();
        }
        private static string LaunchProcessAndGetAbsolutePath(string workingDirectory = null)
        {
            var startInfo = new ProcessStartInfo(@"{SomeAccesibleLocationPath}\ConsoleApplication1.exe");
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardInput = true;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            if (workingDirectory != null)
            {
                startInfo.WorkingDirectory = workingDirectory;
            }
            using (var p = Process.Start(startInfo))
            {
                var ret = p.StandardOutput.ReadLine();
                p.StandardInput.WriteLine();
                p.WaitForExit();
                return ret;
            }
        }
    }
