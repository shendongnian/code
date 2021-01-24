    CheckState Before;
    private void cbCalibrate_CheckedChanged(object sender, EventArgs e)
    {
        if(cbCalibrate.Checked == true)
        {
        Before = cbDenoise.CheckState;
        cbDenoise.Checked = false;
        }
        if(cbCalibrate.Checked == false && Before = true)
        {
            cbDenoise.Checkd = true
        }
    }
