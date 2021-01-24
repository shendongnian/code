        public void InstallWindowsService(string servicePath)
        {
            var isElevated = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
            if (isElevated)
            {
                ExecuteCommand("cmd.exe", string.Format("{0} {1}", InstallUtilArguments(), servicePath));
            }
            else
            {
                throw new Exception("You should run the application as Administrator.");
            }
        }
        private string InstallUtilArguments()
        {
            string framework = @"\Microsoft.NET\Framework\v4.0.30319\installutil.exe";
            if (8 == IntPtr.Size || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))// for 64 bit Windows OS
            {
                framework = @"\Microsoft.NET\Framework64\v4.0.30319\installutil.exe";
            }
            return Environment.GetEnvironmentVariable("windir") + framework;
        }
        public string ExecuteCommand(string fileName, string arguments)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardOutput = true,
                UseShellExecute = false,
            };
            using (Process proc = new Process())
            {
                proc.StartInfo = processStartInfo;
                proc.Start();
                string output = proc.StandardOutput.ReadToEnd();
                if (string.IsNullOrEmpty(output))
                {
                    output = proc.StandardError.ReadToEnd();
                }
                return output;
            }
        }
