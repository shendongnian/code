        private void Rfsh_Click(object sender, EventArgs e)
        {
            ProcessStartInfo Netinfo = new ProcessStartInfo("cmd");
            Netinfo.UseShellExecute = false;
            Netinfo.RedirectStandardOutput = true;
            Netinfo.CreateNoWindow = true;
            Netinfo.RedirectStandardInput = true;
            var proc = Process.Start(Netinfo);
            proc.StandardInput.WriteLine("netsh wlan show hostednetwork | findstr -i ssid");
            proc.StandardInput.WriteLine("exit");
            string Netoutput = proc.StandardOutput.ReadToEnd();
            string output = Netoutput;
            string[] Asplit = new string[] { "ssid" };
            string[] AOut = output.Split(Asplit, StringSplitOptions.RemoveEmptyEntries);
            foreach (var items in AOut)
            {
                Rtxt.Text = items;
            }
            
        }
