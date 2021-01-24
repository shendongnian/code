    private void copyBtn_Click(object sender, EventArgs e)
    {
        labelCopied.Text = "Copied to Clipboard!";
        Clipboard.SetText(btcTxtBox.Text);
        SystemSounds.Hand.Play();
        Timer t = new Timer;
        t.Interval = 2000; //2000 milliseconds = 2 seconds
        t.Tick += (a,b) =>
        {
             labelCopied.Text = string.Empty;
             t.Stop();
        };
     
        t.Start();
    }
