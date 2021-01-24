    for(int x = dataTable.Columns.Count - 1; x >= 0; x--)
    {
       DataColumn dc = dataTable.Columns[x];
       if(dc.ColumnName != "Cat" && dc.ColumnName != "Dog" && 
          dc.ColumnName != "Turtle " && dc.ColumnName != "Lion")
       {
           dc.Columns.Remove(dataColumn)
       }
    }
