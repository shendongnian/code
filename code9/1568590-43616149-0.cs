        string labelText;
        private void yourButton_Click(object sender, EventArgs e)
        {
            labelText = yourLabel.Text; // Save it
            yourLabel.Text = ""; // Hide the text
            yourTimer.Start();
        }
        private void yourTimer_Tick(object sender, EventArgs e)
        {
            yourTimer.Stop();
            yourLabel.Text = labelText;
        }
