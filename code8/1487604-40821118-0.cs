    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {  
        CheckBox c = (CheckBox)sender;
        if(checkBox1.Checked)
        {
            string lb1 = label1.Text + c.Text + "@";
            lb1 = lb1.Replace("@", Environment.NewLine);
            label1.Text = lb1;
        }
        else 
        {
            string str = c.Text + "@";
            str = str.Replace("@", Environment.NewLine);
            label1.Text = label1.Text.Replace(str, "");
        }
