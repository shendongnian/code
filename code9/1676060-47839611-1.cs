    void Main()
    {
        Panel pnl1 = new Panel();
        pnl1.Tag = "A1";
        pnl1.Click += button_click;
        Panel pnl2 = new Panel();
        pnl2.Tag = "A2";
        pnl2.Click += button_click;
        // fire the event, note that the panel instance is the sender
        pnl1.OnClick(null);
        pnl2.OnClick(null);
    }
    private void button_click(object sender, System.EventArgs e)
    {
        var pnl = sender as Panel;
        if (pnl != null && pnl.Tag != null)
            MessageBox.Show("Unique event "+ pnl.Tag.ToString());
    }
