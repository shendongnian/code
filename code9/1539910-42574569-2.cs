    protected void gvBidDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var paraAgreement = e.Row.FindControl("paraAgreement") as HtmlGenericControl;
                paraAgreement.InnerText = "[sample text]";
            }
        }
        catch (Exception ex)
        {
            Utility.Msg_Error(Master, ex.Message);
        }
    }
