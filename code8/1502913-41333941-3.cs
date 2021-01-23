    int indexOfCBColumn = 0;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       e.Row.Cells[indexOfCBColumn].Visible = true;
    }
 
    foreach(GridViewRow row in GridView1.Rows) {
       if(row.RowType == DataControlRowType.DataRow) {
          row.Cells[indexOfCBColumn].Visible = true;
       }
    }
