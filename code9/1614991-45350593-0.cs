    protected void BtnAdd_Click(object sender, EventArgs e)
                {
    foreach (GridViewRow r in GvModules.Rows)
                {
                    //Find the checkbox in the current row 
                    CheckBox chk = (CheckBox)r.FindControl("ChkAdd");
        
               
                    if (chk!=null && chk.Checked)
                    {
                        //code when checkbox checked
                    }
                }
          }
