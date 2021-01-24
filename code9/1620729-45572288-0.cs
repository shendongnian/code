    var results = from row in dt.AsEnumerable()
                  group row by new
                  {
                     Policy = row.Field<int>("POLICY"),
                     StartDt = row.Field<string>("START_DT"),
                     EndDt = row.Field<string>("END_DT")
                  } into groupings
                  select new
                  {
                     groupings.Key.Policy,
                     groupings.Key.StartDt,
                     groupings.Key.EndDt,
                     groupings.First().Field<string>("TYPE"),
                     TotalAmount = groupings.Sum(t => t.Fields<decimal>("AMOUNT"))
                  }
