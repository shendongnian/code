    private void radAllCols_Checked(object sender, EventArgs e)
    {
        if (radAllCols.Checked == true)
        {
            radAllCols.CheckedChanged -= new 
                     EventHandler(this.radAllCols_Checked);
             radSelCols.CheckedChanged -= new 
                     EventHandler(this.radSelCols_Checked);
            radAllCols.Checked = false;
            radSelCols.Checked = true;
            radAllCols.CheckedChanged += new 
                     EventHandler(this.radAllCols_Checked);
             radSelCols.CheckedChanged += new 
                     EventHandler(this.radSelCols_Checked);
        }
    }
    private void radSelCols_Checked(object sender, EventArgs e)
    {
        if (radSelCols.Checked == true)
        {
            radAllCols.CheckedChanged -= new 
                     EventHandler(this.radAllCols_Checked);
             radSelCols.CheckedChanged -= new 
                     EventHandler(this.radSelCols_Checked);
            radSelCols.Checked = false;
            radAllCols.Checked = true;
            radAllCols.CheckedChanged += new 
                     EventHandler(this.radAllCols_Checked);
             radSelCols.CheckedChanged += new 
                     EventHandler(this.radSelCols_Checked);
        }
    }
