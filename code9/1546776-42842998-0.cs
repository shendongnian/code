    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == (Keys.Alt | Keys.Menu))
            this.menuStrip1.Visible = !this.menuStrip1.Visible;
        return base.ProcessCmdKey(ref msg, keyData);
    }
    private void menuStrip1_MenuDeactivate(object sender, EventArgs e)
    {
        this.menuStrip1.Visible = false;
    }
