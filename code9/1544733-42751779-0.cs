    foreach(DataGridViewColumn searchCol in junctionTableDependencies.Values)
    {
       foreach(DataGridViewRow thisRow in searchCol.DataGridView.Rows)
       {
          var value = thisRow.Cells[searchCol.Name];
          if (value == "whateverYouNeed")
          {
             // Code...
          }
       }
    }
