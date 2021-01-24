        Task.Run(async () => 
        {
            while (true)
            {
                while (checkBox1.Checked)
                {
                    var retVal = Process.GetProcesses().Any(p => p.ProcessName.Contains(textBox1.Text));
                    if (retVal.Equals(true))
                    {
                        listBox1.Items.Add(textBox1.Text + @" " + @"is running." + @" " + DateTime.Now);
                        return;
                    }
                    if (retVal.Equals(false))
                    {
                        listBox1.Items.Add(
                            textBox1.Text + @" " + @"is not running, attempting to start." + DateTime.Now);
                        Process.Start(textBox2.Text);
                        return;
                    }
                }
                await Task.Delay(2 /*your waiting time in seconds*/ * 1000);
            }
        });
