    class Program
    {
        static void Main(string[] args)
        {
            if (args == null)
                Environment.Exit(-1);
            string exeIIS = args[0];
            string websitePath = args[1];
            string port = args[2];
            string argsIIS = MakeIISExpressArgs(websitePath, port);
            int processID = LaunchIISExpress(argsIIS, exeIIS);
            Environment.Exit(processID);
        }
        private static int LaunchIISExpress(string argsIIS, string pathExeIIS)
        {
            var process = Process.Start(new ProcessStartInfo()
            {
                FileName = pathExeIIS,
                Arguments = argsIIS,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            });
            return process.Id;
        }
        private static string MakeIISExpressArgs(string websitePath, string port)
        {
            var argsIIS = new StringBuilder();
            argsIIS.Append(@"/path:" + websitePath);
            argsIIS.Append(@" /Port:" + port);
            return argsIIS.ToString();
        }
    }
