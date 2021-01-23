    int indexOfYourTemplateColumn = 0;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if(e.Row.RowType == DataControlRowType.DataRow) 
      {
       HtmlInputText txt = (e.Row.FindControl("id") as HtmlInputText);
       string txtValue = txt.Value;
      }
    }
    foreach(GridViewRow row in GridView1.Rows) {
     if(row.RowType == DataControlRowType.DataRow) {
       HtmlInputText txt = (row.FindControl("id") as HtmlInputText);
       string txtValue = txt.Value;
       }
     }
