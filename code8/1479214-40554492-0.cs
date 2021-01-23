        protected void BindData(DataTable dt)
        {
            GridView gvEmployee = new GridView();
            gvEmployee.AllowPaging = true;
            gvEmployee.PageSize = 4;//this Will work now
            gvEmployee.AutoGenerateColumns = false;
            if (dt != null)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    BoundField boundfield = new BoundField();
                    boundfield.DataField = dt.Columns[i].ColumnName.ToString();
                    boundfield.HeaderText = dt.Columns[i].ColumnName.ToString();
                    gvEmployee.Columns.Add(boundfield);
                }
                gvEmployee.DataSource = dt;
                gvEmployee.RowDataBound += gvEmployee_RowDataBound;
                gvEmployee.PagerTemplate = new MyTemplate();
                gvEmployee.DataBind();
                gvEmployee.Width = 600;
                gvEmployee.HeaderStyle.CssClass = "header";
                gvEmployee.RowStyle.CssClass = "rowstyle";
                Panel1.Controls.Add(gvEmployee);
            }
        }
        void gvEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.DataRow:
                    break;
                case DataControlRowType.EmptyDataRow:
                    break;
                case DataControlRowType.Footer:
                    break;
                case DataControlRowType.Header:
                    break;
                case DataControlRowType.Pager:
                    //TODO: handle you pager...
                    break;
                case DataControlRowType.Separator:
                    break;
                default:
                    break;
            }
        }
