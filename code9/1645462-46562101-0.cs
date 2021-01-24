    var dateGroups  = dt.AsEnumerable().GroupBy(row => row["ColumnName of Date Time"]);
    foreach (var group in dateGroups)
    {
     // the group.Key will give the Date on the basis of which you can create sheets. 
    // and then your logic of excel
      foreach (var rows in group)
      {
       // excel filling logic
      }
    }
