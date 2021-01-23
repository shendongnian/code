    private void buttonNewRow_Click(object sender, EventArgs e)
    {
            Uc1 c = new Uc1();
            c.Dock = DockStyle.Top;
            c.BringToFront();
            this.panel.Controls.Add(c);
    }
