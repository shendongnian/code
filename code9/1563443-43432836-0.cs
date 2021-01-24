                DataTable dt = getDataTable();
    
                var sortExprOrder = e.SortDirection == SortDirection.Ascending ? " ASC" : " DESC";
    
                DataView dv = new DataView(dt);
                dv.Sort = string.Format("{0} {1}",
                    e.SortExpression, sortExprOrder);
    
                grdEmployees.DataSource = dv;
                grdEmployees.DataBind();
            }
