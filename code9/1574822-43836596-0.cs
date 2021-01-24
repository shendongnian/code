    if (dsBOMInvoice.Tables[0].Rows.Count > 0)
    {
        foreach (DataRow dr in dsBOMInvoice.Tables[0].Rows)
        {
            var BOQ_ID = dr["BOQ_ITEM_ID"].ToString();
    
            foreach (GridViewRow BOMrow in grdBOM.Rows)
            {
               // step1: find the label or textbox which you wan to check in grid
               // Step2: check with BOQ_ID by using if
               //find the textbox for setting using Findcontrol and set
            }
        }
    
    }
