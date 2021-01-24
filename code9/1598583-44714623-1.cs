    protected void RadGrid1_PreRender(object sender, EventArgs e)
    {
    if ("your Condition")
    {
        foreach (GridDataItem dataItem in RadGrid1.MasterTableView.Items)
        {
            ((Button)cmdItem.FindControl("btnEditReportDetail")).Visible = false;
        }
    }
    }
