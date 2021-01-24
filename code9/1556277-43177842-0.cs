            // Approach 1
            Utility.NetworkDrive.MapNetworkDrive("R", @"\\unc\path");
            var dirs1 = Directory.GetDirectories("R:");
            Utility.NetworkDrive.DisconnectNetworkDrive("R", true);
            // Approach 2
            DoProcess("net", @"use R: \\unc\path");
            var dirs2 = Directory.GetDirectories("R:");
            DoProcess("net", "use /D R:");
            // Approach 3
            DoProcess("cmd", @"/c C:\local\path\to\batch\connect.cmd");
            var dirs3 = Directory.GetDirectories("R:");
            DoProcess("cmd", @"/c C:\local\path\to\batch\diconnect.cmd");
        public static string DoProcess(string cmd, string argv)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = cmd;
            p.StartInfo.Arguments = $" {argv}";
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.WaitForExit();
            string output = p.StandardOutput.ReadToEnd();
            p.Dispose();
            return output;
        }
