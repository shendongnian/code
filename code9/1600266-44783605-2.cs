    FlowLayoutPanel pnl = new FlowLayoutPanel();
    pnl.Dock = DockStyle.Fill;
    for (int i = 0; i < 4; i++)
    {
        pnl.Controls.Add(new RadioButton() { Text = "RadioButton" + i });
    }
    this.Controls.Add(pnl);
