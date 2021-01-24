    private void SetTabControlEnabled(bool enabled)
    {
        foreach (TabPage tabPage in tabControl1.TabPages)
        {
            foreach (Control control in tabPage.Controls)
            {
                control.Enabled = enabled;
            }
        }
    }
