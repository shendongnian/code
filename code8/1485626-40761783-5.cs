            if (!File.Exists(Path.Combine(Environment.SystemDirectory, @"wbadmin.exe")))
            {
                Console.WriteLine("wbadmin.exe not found");
                return;
            }
            Process pr = new Process();
            ProcessStartInfo psi = new ProcessStartInfo(@"wbadmin.exe");
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.Arguments = "/?"; // prints avaliable commands
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.Verb = "runas";
            psi.StandardOutputEncoding = enc;
            psi.StandardErrorEncoding = enc;
            pr.StartInfo = psi;
            pr.Start();
            pr.WaitForExit(1000);
            string error = pr.StandardError.ReadToEnd();
            
            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine("error: " + error);
                pr.Close();
                pr.Dispose();
                return;
            }
            string output = pr.StandardOutput.ReadToEnd();
            pr.Close();
            pr.Dispose();
