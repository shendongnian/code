    progressbar.Value = percent.
    if(percent>=100)
    {
        MyTimer.Enabled = false;
        MessageBox.Show("Finished!");
    }
