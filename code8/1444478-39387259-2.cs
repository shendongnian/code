    private void btn_MouseEnter(object sender, System.EventArgs e) 
    {
        var senderButton = (Button)sender;
        foreach(var btn in this.Controls.OfType<Button>())
        {
            if (btn != senderButton)
                btn.Enabled = false;
        }
    }
    private void btn_MouseLeave(object sender, System.EventArgs e)
    {
        foreach(var btn in this.Controls.OfType<Button>())
        {
            (sender as Button).Enabled = true;
        }
    }
