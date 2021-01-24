    private void buttons_Leaveobject sender, EventArgs e)
    {
        ((Button)sender).BackColor = SystemColors.Control;
        ((Button)sender).ForeColor = SystemColors.ControlText;
    }
    private void buttons_Enter((object sender, EventArgs e)
    {
        ((Button)sender).ForeColor = SystemColors.Control;
        ((Button)sender).BackColor = SystemColors.ControlText;
    }
