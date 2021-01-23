    private void label1_Click(object sender, EventArgs e)
    {
        TextBox tb = null;
        if (label1.Controls.Count > 0)
        {
            tb = ((TextBox)label1.Controls[0]);
            if (tb.Visible) { label1.Text = tb.Text; tb.Hide(); return; };
        }
        else
        {
            tb = new TextBox();
            tb.Parent = label1;
            tb.Size = label1.Size;
            tb.LostFocus += (ss, ee) =>
                { label1.Text = tb.Text; tb.Hide(); };
        }
        tb.Text = label1.Text;
        tb.Show();
    }
