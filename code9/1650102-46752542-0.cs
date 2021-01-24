    private void button1_Click(object sender, EventArgs e)
    {
        SetBackColorRecursively(this);
    }
    private void SetBackColorRecursively(Control ctrl)
    {
        if (ctrl is Panel)
        {
            (ctrl as Panel).BackColor = Color.FromArgb(214, 219, 233);
        }
        if (ctrl is GroupBox)
        {
            (ctrl as GroupBox).BackColor = Color.FromArgb(214, 219, 233);
        }
        // Recursively set BackColor on all children
        foreach (Control c in ctrl.Controls)
        {
            SetBackColorRecursively(c);
        }
    }
