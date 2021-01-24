    private async void copyBtn_Click(object sender, EventArgs e)
    {
        labelCopied.Text = "Copied to Clipboard!";
        Clipboard.SetText(btcTxtBox.Text);
        SystemSounds.Hand.Play();
        await Task.Delay(2000);
        labelCopied.Text = "";
    }
