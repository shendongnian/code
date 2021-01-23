    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        label1.Text = (label1.Tag as string);
        if (checkBox1.Checked)
        {
            label1.Text += checkBox1.Text;
        }
        if (checkBox2.Checked)
        {
            label1.Text += checkBox2.Text;
        }
        if (checkBox3.Checked)
        {
            label1.Text += checkBox3.Text;
        }
        label1 += Environment.NewLine;
    }
