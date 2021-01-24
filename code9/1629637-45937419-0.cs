    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!CheckBox1.Checked)
            {
                if (CheckBox2.Checked)
                {
                    CheckBox2.Checked = false;
                }
            }
    }
