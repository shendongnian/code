    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        while(checkBox1.Checked == true)
        {
            Play();
            Application.DoEvents();
        }
    }
