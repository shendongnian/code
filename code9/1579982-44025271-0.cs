        private bool AllowUpdate = true;
        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {
            if (AllowUpdate)
            {
                AllowUpdate = false; // don't allow updates until after delay
                // ... hit the database ...
                // ... update your text ...
                timer1.Start(); // don't allow updates until after delay
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // reset so it can be updated again
            AllowUpdate = true;
            timer1.Stop();
        }
