        public void RowDataBound(object sender, GridViewRowEventArgs e)
        {
                DataRow row = ((DataRowView)e.Row.DataItem).Row;
                if (!row.Field<Boolean>("IsActive"))
                {
                    e.Row.Attributes["class"] += "InActive";
                }
		}
        protected void PreRender(object sender, EventArgs e)
        {
            foreach(GridViewRow row in GridView1.Rows)
            {
                if ((row.Attributes["class"] == "InActive")&& (row.RowState == DataControlRowState.Alternate)){
                    row.RowState = DataControlRowState.Normal;
                    row.Attributes["class"] = String.Format("gvAlternatingStyle {0}", row.Attributes["class"]);
                }
            }
        }
		
