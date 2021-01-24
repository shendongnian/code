    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gvOrders = (GridView)e.Row.FindControl("gvOrders");
            foreach (GridViewRow row in gvOrders.Rows)
            {
                LinkButton lnkDownload = (LinkButton)row.FindControl("lnkDownload");
                HiddenField hf = (HiddenField)row.FindControl("HiddenField1");
                if (!String.IsNullOrEmpty(lnkDownload.Text))
                {
                    //... some code
                }
            }
        }
    }
