     protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
                {
        
                    DataSet ds = new DataSet();
                    B.id = 2;
                    ds = A.DATA(B);
                    GvUser.DataSource = ds.Tables[0];
                    GvUser.DataBind();
        
                    if (ds.Tables[0] != null)
                    {
                        DataView dataView = new DataView(ds.Tables[0]);
                        dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
        
                        GvUser.DataSource = dataView;
                        GvUser.DataBind();
                    }
                }
        
                private string GridViewSortDirection
                {
                    get { return ViewState["SortDirection"] as string ?? "DESC"; }
                    set { ViewState["SortDirection"] = value; }
                }
        
                private string ConvertSortDirectionToSql(SortDirection sortDirection)
                {
                    switch (GridViewSortDirection)
                    {
                        case "ASC":
                            GridViewSortDirection = "DESC";
                            break;
        
                        case "DESC":
                            GridViewSortDirection = "ASC";
                            break;
                    }
        
                    return GridViewSortDirection;
                }
