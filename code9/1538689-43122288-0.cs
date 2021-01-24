    private void addPorts_Click(object sender, EventArgs e)
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.StandardInput.WriteLine(@"
    @echo Enabling SQLServer default instance port 1433
    netsh advfirewall firewall add rule name =""SQLServer"" dir =in action = allow protocol = TCP localport = 1433
    @echo Enabling Dedicated Admin Connection port 1434");
                process.StandardInput.Flush();
                process.StandardInput.Close();
                process.WaitForExit();
                Console.WriteLine(process.StandardOutput.ReadToEnd());
                //Console.ReadKey();
                MessageBox.Show("Succesful!", "Succesful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
