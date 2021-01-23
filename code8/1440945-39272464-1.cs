    progressbar.Value = percent.
    if(percent>=100)
    {
        MessageBox.Show("Finished!");
        MyTimer.Enabled = false;
    }
