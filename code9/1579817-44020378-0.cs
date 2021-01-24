     protected void GridUserMessage_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
      // Check database column has value or not.  
      if(String.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ColumnNameOfDataYouWantToCheck")))
        {
            e.Row.BackColor = System.Drawing.Color.Red;
        }
     }
    }
