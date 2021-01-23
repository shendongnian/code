    protected void timeSelector_CheckedChanged(object sender, EventArgs e)
    {
        if (currentOption.Checked)
        {              
            loadCurrentData();
        }
        else
        {
            loadPastData();
        }
    }
