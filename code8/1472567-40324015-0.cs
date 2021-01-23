    //mark the process as running (check box is Indeterminate state)
    private bool processIsRunning = true;
    
    private void chkState_CheckStateChanged(object sender, EventArgs e)
    {
        //the user clicks the indeterminate checkbox
        if (processIsRunning && chkState.CheckState == CheckState.Unchecked)
        {
            processIsRunning = false;
            chkState.CheckState = CheckState.Checked;
        }
    }
