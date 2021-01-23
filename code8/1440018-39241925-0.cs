    public void button1_Click(object sender, EventArgs e)
        {
            // Start the child process.
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "C:\\Windows\\Microsoft.NET\\Framework\\v3.5\\csc.exe";
            p.StartInfo.Arguments = textBox1.Text;
            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            label1.Text = p.StandardOutput.ReadToEnd();
            MessageBox.Show(output);
            p.WaitForExit();
        }
