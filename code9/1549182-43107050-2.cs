    protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView gv = (GridView)sender;
        gv.PageIndex = e.NewPageIndex;
        gv.DataBind();
    }
    
    protected void GridView_PageIndexChanged(object sender, EventArgs e)
    {
        //here we control gridviews that have more than 10 rows so we can paginate and fill in rows like
        //we did above in GridView_Load(). But it could not be done there because we're adding more rows
        //to a gridview that has not had it's paging reformatted! We're doing so here
    
        GridView gv = (GridView)sender;
    
        //padd with blank rows to make up a full gridview of PAGESIZE (default 10) rows per page
        DataSourceSelectArguments dss = new DataSourceSelectArguments();
    
        //get the datasource related to the gridview
        string wsDataSourceID = (gv.DataSourceID == string.Empty) ? ViewState["DataSourceID"].ToString() : gv.DataSourceID;
        SqlDataSource sds = (SqlDataSource)pnlMAIN.FindControl(wsDataSourceID);
        if (sds != null)
        {
            //load the data again but this time into a dataview object
            DataView dv = (DataView)sds.Select(DataSourceSelectArguments.Empty);
            if (dv != null)
            {
                //convert the dataview to a datatable so we can see the row(s)
                DataTable dt = (DataTable)dv.ToTable();
                if (dt != null)
                {
                    //have we reached the LAST page?
                    if ((gv.PageIndex + 1) == ((gv.PageCount == 0) ? Convert.ToInt16(ViewState[wsDataSourceID + "PageCount"].ToString()) : gv.PageCount))
                    {
                        //determines actual number of rows on the last page
                        int lastPageRowCount = dt.Rows.Count % gv.PageSize;
                        if (lastPageRowCount < gv.PageSize)
                        {
                            //loop through any "gap rows" and add empty rows
                            for (int wsRowAdd = (lastPageRowCount + 1); wsRowAdd <= gv.PageSize; wsRowAdd++)
                            {
                                DataRow dr = dt.NewRow();
                                dt.Rows.Add(dr);
                            }
    
                            //accept the new rows
                            dt.AcceptChanges();
                        }
                    }
    
                    //reload the datatable back to the gridview (either with extra rows, or the original data to not stuff up the paging)
                    gv.DataSource = dt;
                    if (gv.DataSourceID != string.Empty)
                        ViewState["DataSourceID"] = gv.DataSourceID;
                    gv.DataSourceID = null;
                    gv.DataBind();
                }
            }
        }
    }
