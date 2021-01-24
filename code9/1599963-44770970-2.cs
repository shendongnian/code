    public void ButtonClick(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        btn.Text = btn.Name;  //only for demo
    }
