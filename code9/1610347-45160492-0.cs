    private void radAllCols_Checked(object sender, EventArgs e)
     {
       radAllCols.Checked = !radSelCols.Checked;
     }
    private void radSelCols_Checked(object sender, EventArgs e)
     {
       radSelCols.Checked = !radAllCols.Checked;
     }
