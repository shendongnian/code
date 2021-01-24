    private void radSelCols_Checked(object sender, EventArgs e)
    {
        if (radSelCols.Checked == true)
        {
            radSelCols.Checked = false; // reversed
            radAllCols.Checked = true; // reversed
         }
    }
