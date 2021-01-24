    private void OnStartbuttonClicked(object sender, EventArgs e)
        {
            // Save the Time, when the Timer starts
        }
        private void OnStopbuttonClicked(object sender, EventArgs e)
        {
            DateTime starttime = DateTime.Parse("String with the Time, when the Timer starts");
            DateTime endTime = DateTime.Now;
            TimeSpan difference = endTime - starttime;
            // difference ist the time of the timer
        }
