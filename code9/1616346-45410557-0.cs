    foreach (GridViewRow row in grdApproverDetails.Rows)
    {
        for (int i = 0; i < row.Controls.Count; i++)
        {
            Control control = row.Controls[i];
            if(control is CheckBox)
            {
                CheckBox chk = control as CheckBox;
                if(chk != null && chk.Checked)
                //...
            }
        }
    }
