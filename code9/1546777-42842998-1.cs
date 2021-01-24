    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == (Keys.Alt | Keys.Menu))
        {
            if (!this.menuStrip1.Visible)
            {
                this.menuStrip1.Visible = true;
                var OnMenuKey = menuStrip1.GetType().GetMethod("OnMenuKey", 
                    System.Reflection.BindingFlags.NonPublic | 
                    System.Reflection.BindingFlags.Instance);
                OnMenuKey.Invoke(this.menuStrip1, null);
            }
            else
            {
                this.menuStrip1.Visible = false;
            }
            return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
    private void menuStrip1_MenuDeactivate(object sender, EventArgs e)
    {
        this.BeginInvoke(new Action(() => { this.menuStrip1.Visible = false; }));
    }
