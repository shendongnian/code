     // Setup bar Animation and disable all buttons
        private void BarAnimation(object sender, EventArgs e)
        {
            toolStripProgressBar1.MarqueeAnimationSpeed = 1;
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
        }
        private void ProcExited(object sender, EventArgs e)
        {
            toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
            button1.Enabled = true;
        }
 
