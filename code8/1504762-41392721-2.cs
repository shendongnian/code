    protected void GridDataBound(object sender, EventArgs e)
    {
     GridView gridView = (GridView)sender;
     DataTable dt = (DataTable)gridView.DataSource;
     decimal sum =  dt.AsEnumerable().Sum(r => r.Field<decimal>("Amount"));
     var newRow = dt.NewRow();
     newRow["Name"] = "Total";
     newRow["Amount"] = sum.ToString();
     dt.Rows.Add(newRow);
    }
   
