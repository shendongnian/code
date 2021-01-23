        private bool panel1WasClicked = false;
        private bool panel2WasClicked = false;
        int second = 0;
        private void panel1_Click(object sender, EventArgs e)
        {
            MaintenanceTimer.Interval = 500;
            MaintenanceTimer.Start();
            second = 0;
            if (panel1WasClicked == false)
            {
                panel1WasClicked = true;
            }
            else
            {
                panel1WasClicked = false;
            }
        }
        private void panel2_Click(object sender, EventArgs e)
        {
            if (panel2WasClicked == false && panel1WasClicked == true)
            {
                panel2WasClicked = true;
            }
            else
            {
                panel2WasClicked = false;
            }
        }
        private void panel3_Click(object sender, EventArgs e)
        {
            if (panel1WasClicked && panel2WasClicked == true)
            {
                //Do something
            }
            panel1WasClicked = false;
            panel2WasClicked = false;
            MaintenanceTimer.Stop();
        }
        private void MaintenanceTimer_Tick(object sender, EventArgs e)
        {
            second += 1;
            if (second >= 5)
            {
                MaintenanceTimer.Stop();
                second = 0;
                panel1WasClicked = false;
                panel2WasClicked = false;
            }
        }
