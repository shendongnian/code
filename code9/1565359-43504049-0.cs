    protected void grdDateReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdDateReport.PageIndex = e.NewPageIndex;
        BindGrid();
        if (grdDateReport.PageCount == e.NewPageIndex + 1)
        {
            grdDateReport.FooterRow.Cells[0].Text = string.Format("{0:N2}", total);
        }
    }
