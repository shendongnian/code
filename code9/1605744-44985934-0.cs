    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    
      if (e.Row.RowType == DataControlRowType.HeaderRow)
      {
       //Initialize totals array
       for (int k=0; k<=maxTotals; k++)
         totals[k]=0;
      }
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
       //Collect totals from relevant cells
       DataRowView rowView = (DataRowView)e.Row.DataItem;
       for (int k=0; k<=maxTotals; k++)
          totals[k] += (Decimal)rowView[k];
      }
      if (e.Row.RowType == DataControlRowType.FooterRow)
      {
       //Show totals
       for (int k=0; k<=maxTotals; k++)
         e.Row.Cells[k].Text = String.Format("{0:c}",totals[k]);
      }
    }
     
