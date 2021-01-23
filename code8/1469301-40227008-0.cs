        private void timer1_Tick(object sender, EventArgs e)
        {
            System.Diagnostics.Process[] processList1 = System.Diagnostics.Process.GetProcesses();
            DateTime min = processList1[0].StartTime;
            Process last = new Process();
            foreach (Process a in processList1)
            {
                try
                {
                    if (DateTime.Compare(a.StartTime, min) >= 0)
                    {
                        last = a;
                        min = a.StartTime;
                    }
                }
                catch (Exception)
                {
                }
            }
            label1.Text = last.ProcessName;
        }
    
