    // taken from /a/15708885/6378815
    public static Control FindControlRecursive(Control parentControl, string id)
    {
       if (parentControl.ID == id) 
       {
           return parentControl;
       }
    
       return parentControl.Controls.Cast<Control>().Select(c => FindControlRecursive(c, id)).FirstOrDefault(c => c != null);
    }
    // GridView event method
    protected void gvBindDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var paraAgreement = new HtmlGenericControl();
                foreach (Control control in gvBindDetails.Rows)
                {
                    paraAgreement = FindControlRecursive(control, "paraAgreement") as HtmlGenericControl;
                }
    
                paraAgreement.InnerText = "[sample text]";
            }
        }
        catch (Exception ex)
        {
            Utility.Msg_Error(Master, ex.Message);
        }
    }
