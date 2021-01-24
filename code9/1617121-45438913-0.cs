    private void Form1_KeyUp(object sender, KeyEventArgs e)
    {
        // Replace "Keys.A" with the key you want
        if (e.KeyCode == Keys.A && e.Alt)
        {
            this.firstMatch_Button.PerformClick();
        }
    }
