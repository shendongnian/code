    public void PauseButton_Click(object sender, EventArgs e)
    {
        if (PauseButton.Text == "Pause")
        {
            timerx.Stop();
            PauseButton.Text = "Start";
            stopTime = DateTime.Now;
        }
        else
        {
            PauseButton.Text = "Pause";
            startTime += (DateTime.Now - stopTime);
            timerx.Start();
            TimerLabel.Visible = true;
            timerx.Enabled = true;
        }
    }
