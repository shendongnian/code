        protected void GridView_Load(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            
            DataSourceSelectArguments dss = new DataSourceSelectArguments();
        
            //get the datasource related to the gridview
            SqlDataSource sds = (SqlDataSource)pnlMAIN.FindControl(gv.DataSourceID.ToString());
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
                        //padd with blank rows to make up a full gridview of PAGESIZE (default 10) rows per page
                        if (gv.Rows.Count < gv.PageSize)
                        {
                            //and this is necessary to not stuff up gridviews with data beyond PageSize rows. Otherwise we'll have to handle the paging in code!
                            if (dt.Rows.Count <= gv.PageSize)
                            {
                                //loop through any "gap rows" and add empty rows
                                for (int wsRowAdd = (gv.Rows.Count + 1); wsRowAdd <= gv.PageSize; wsRowAdd++)
                                {
                                    DataRow dr = dt.NewRow();
                                    dt.Rows.Add(dr);
                                }
        
                                //accept the new rows
                                dt.AcceptChanges();
        
                                //reload the datatable back to the gridview
                                gv.DataSource = dt;
                                if (gv.DataSourceID != string.Empty)
                                    ViewState["DataSourceID"] = gv.DataSourceID;
                                gv.DataSourceID = null;
                                gv.DataBind();
                            }
                        }
        
                        //hide gridview and reveal "emptyrow" label if there is no data to display
                        GridViewRow gHDR = (GridViewRow)gv.HeaderRow;
                        CheckBox cbHDR = (CheckBox)gHDR.FindControl("cbHDR");
                        if (gvNoData(gv))
                        {
                            gv.Visible = false;
                            Label lblEmpty = new Label();
    ((Label)pnlMAIN.FindControl("lblEmptyRow")).Style.Add("display", "");
                        }
                    }
                }
            }
        }
