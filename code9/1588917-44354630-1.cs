    var dt1 = dtCurtable.AsEnumerable()
                  .GroupBy(r => r.Field<string>("realid"))
                  .Select(g =>
                  {
                  DataRow row = dtCurtable.NewRow();
                  row["realid"] = g.Key;
                  row["Count"] = g.Sum(r => r.Field<int>("counts"));
                  return row;
              }).CopyToDataTable();
