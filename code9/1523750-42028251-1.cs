    ToolStripControlHost host;
    FlowLayoutPanel panel;
    private void button1_Click(object sender, EventArgs e)
    {
        if (panel == null)
        {
            panel = new FlowLayoutPanel();
            panel.FlowDirection = FlowDirection.TopDown;
            panel.WrapContents = false;
            panel.AutoSize = true;
            panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        }
        if (host == null)
        {
            host = new ToolStripControlHost(panel);
            this.statusStrip1.Items.Add(host);
        }
        panel.Controls.Add(new ProgressBar() { /* Value = new Random().Next(0, 100) */ });
    }
