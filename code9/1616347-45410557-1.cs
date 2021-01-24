    foreach (GridViewRow row in grdApproverDetails.Rows)
    {
        for (int k = 0; k < row.Cells.Count; k++)
        {
           for (int i = 0; i < row.Cells[k].Controls.Count; i++)
           {
               Control control = row.Cells[k].Controls[i];
               if(control is CheckBox)
               {
                   CheckBox chk = control as CheckBox;
                   if(chk != null && chk.Checked)
                   //...
               }
           }
        }
    }
