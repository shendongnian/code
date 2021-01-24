           private void AutoRScb_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoRScb.Checked.Equals(true) && textBox1.Text.Length > 0)
            {
                var timeToWait = double.Parse(textBox1.Text) * 1000;
                rsTimer.Interval = timeToWait;
                rsTimer.Enabled = true;
            }
            if (AutoRScb.Checked.Equals(false))
            {
                rsTimer.Stop();
                rsTimer.Dispose();
            }
            if (rsTimer.Enabled == true)
            {
                MessageBox.Show("enabled");
                rsTimer.Elapsed += OnTimedEvent;
                void OnTimedEvent(object source, ElapsedEventArgs elapsed)
                {
                    try
                    {
                        foreach (var procs in Process.GetProcessesByName(comboBox2.Text))
                            procs.Kill();
                        Thread.Sleep(1000);
                        var proc = new Process();
                        proc.StartInfo.FileName = textBox4.Text;
                        if (textBox8.Text.Length > 0)
                            proc.StartInfo.WorkingDirectory = textBox8.Text;
                        proc.Start();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        throw;
                    }
                }
            }
            if (rsTimer.Enabled == false)
            {
                MessageBox.Show("disabled");
            }
        }
