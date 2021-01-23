    DataTable dt3 = dt1.Copy();
    dt3.Merge(dt2);
    var grouped=dt3.AsEnumerable().GroupBy(x => x.Field<int>("RowNo"));
    List<int> RowsModified = new List<int>();
    foreach(var group in grouped)
    {
         if (group.Count() > 1)
         {
               DataRow dr = dt1.NewRow();
               foreach (var row in group)
               {
                    if (dr["RowNo"] == DBNull.Value)
                    {
                        dr = row;
                    }
                    else
                    {
                        if (!dr.ItemArray.SequenceEqual(row.ItemArray))
                        { 
                             RowsModified.Add(group.Key);
                             break;
                        }
                    }
               }
          }
    }
