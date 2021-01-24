    void Main()
    {
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                myPanels[i, j].Tag = i +" - " + j;
                myPanels[i, j].Click += button_click;
                // fire the event, note that the panel instance is the sender
                myPanels[i, j].OnClick(null);
            }
        }
    }
    private void button_click(object sender, System.EventArgs e)
    {
        var pnl = sender as Panel;
        if (pnl != null && pnl.Tag != null)
            MessageBox.Show("Unique event "+ pnl.Tag.ToString());
    }
