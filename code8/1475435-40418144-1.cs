    private void label1_Click(object sender, EventArgs e)
    {
        TextBox tb = label1.Controls.Count > 0 ?
                      ((TextBox)label1.Controls[0] ) : new TextBox();
        tb.Parent = label1;
        tb.Text = label1.Text;
        tb.Size = label1.Size;
        tb.Show();
        tb.Leave -= (ss, ee) =>  { label1.Text = tb.Text; tb.Hide(); };
        tb.Leave += (ss, ee) =>  { label1.Text = tb.Text; tb.Hide(); };
    }
