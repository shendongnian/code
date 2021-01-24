    private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
    {
        if (checkBox1.CheckState == CheckState.Checked)
        {
            this.TopMost = true;
        }
        else
        {
            this.TopMost = false;
        }
    }
