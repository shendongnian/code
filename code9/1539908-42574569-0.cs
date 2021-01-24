    protected void gvBidDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // note that FindControl method searches only control which is directly contained by parent control
                // hence, HTML server control should be found in Panel control inside GridView
                var panel = e.Row.FindControl("pnlPopup2") as Panel;
                var paraAgreement = panel.FindControl("paraAgreement") as HtmlGenericControl;
                paraAgreement.InnerText = "[sample text]";
            }
        }
        catch (Exception ex)
        {
            Utility.Msg_Error(Master, ex.Message);
        }
    }
