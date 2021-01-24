    foreach (GridViewRow row in grdApproverDetails.Rows)
    {
         List<CheckBox> listCkb = new List<CheckBox>();
                  
         ControlCollection cntrColl=  row.Cells[2].Controls;
         foreach (Control cntr in cntrColl)
         {
             if (cntr is CheckBox && cntr.ID.Contains("approvernamesdynamic_"))
             {
             }
          }
    }
