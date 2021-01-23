    foreach (Control c in Page.Controls)
    {
        TextBox       t = (c as TextBox);
        NumericUpDown n = (c as NumericUpDown);
        if (t != null)
            t.Text = "";
        if (n != null)
            n.Value = 0;
    }
