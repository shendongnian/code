        protected void gvExample_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // access the div here
                HtmlGenericControl tempDiv = (HtmlGenericControl) e.Row.FindControl("temp");
                tempDiv.Attributes.Add("style", "width: 50%;");
            }
        }
