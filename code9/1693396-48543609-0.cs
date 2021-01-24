        public ImAConstructor()
        {
            rsTimer.Elapsed += OnTimedEvent;
        }
        public void OnTimedEvent(object source, ElapsedEventArgs elapsed)
        {
            try
            {
                UpdateList("test");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        private void checkconnect_CheckedChanged(object sender, EventArgs e)
        {
            if (checkconnect.Checked)
                rsTimer.Start();
            else
                rsTimer.Stop();
            if (rsTimer.Enabled)
            {
                Shorestatuslbl.Text = "Checking";
                buoystatuslbl.Text = "Checking";
                nistatuslbl.Text = "Checking";
            }
            else
            {
                Shorestatuslbl.Text = "Idle";
                buoystatuslbl.Text = "Idle";
                nistatuslbl.Text = "Idle";
            }
        }
