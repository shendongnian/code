    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (ComboBox.Text == "")
        {
            MessageBox.Show("Select a drive");
        }
        else
        {
            ProgressRing.IsActive = true;
            string text = ComboBox.Text;
            Task.Factory.StartNew(() =>
            {
                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();
                cmd.StandardInput.WriteLine("attrib -r -s -h " + text + "*.* /s /d");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
            }).ContinueWith(task =>
            {
                ProgressRing.IsActive = false;
                if (task.IsFaulted)
                {
                    Console.WriteLine("{0} Exception caught.", task.Exception);
                    MessageBox.Show("Error");
                }
            }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
