        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (Hidden4.Value == "Data Present")
            { 
                   if (e.Row.RowType == DataControlRowType.DataRow)
                   {
                      DataRow row = ((DataRowView)e.Row.DataItem).Row;
                      string test = row.Field<String>("Test");
           
                      if (test== "Y")
                      {
                         e.Row.Cells[0].BackColor = Color.Gray; // set your index
                         e.Row.Attributes.Add("onmouseover", "alert('This data is for testing');");
                     }
                  }
           }
        }
