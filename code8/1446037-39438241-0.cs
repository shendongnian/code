        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onclick", "javascript:location.href='" + DataBinder.Eval(e.Row.DataItem, "url").ToString() + "'");
            }
        }
