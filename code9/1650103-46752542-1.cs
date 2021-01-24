    private void button1_Click(object sender, EventArgs e)
    {
        foreach (Control ctrl in Flatten(this))
        {
            if (ctrl is Panel)
            {
                (ctrl as Panel).BackColor = Color.FromArgb(214, 219, 233);
            }
            if (ctrl is GroupBox)
            {
                (ctrl as GroupBox).BackColor = Color.FromArgb(214, 219, 233);
            }
        }
    }
    static IEnumerable<Control> Flatten(Control c)
    {
        yield return c;
        foreach (Control o in c.Controls)
        {
            foreach (var oo in Flatten(o))
                yield return oo;
        }
    }
