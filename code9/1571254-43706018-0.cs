        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!checkBox1.Checked) return;
            var retVal = Process.GetProcesses().Any(p => p.ProcessName.Contains(textBox1.Text));
            if (retVal.Equals(true))
            {
                listBox1.Items.Add(textBox1.Text + @" " + @"is running." + @" " + DateTime.Now);
                return;
            }
            if (!retVal.Equals(false)) return;
            listBox1.Items.Add(textBox1.Text + @" " + @"is not running, attempting to start." + DateTime.Now);
            Process.Start(textBox2.Text);
        }
