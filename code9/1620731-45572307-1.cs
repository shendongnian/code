    var results = from row in dt.AsEnumerable()
              group row by new
              {
                 Policy = row.Field<int>("POLICY"),
                 StartDt = row.Field<string>("START_DT"),
                 EndDt = row.Field<string>("END_DT"),                 
              } into groupings
              select new
              {
                 Policy = groupings.Key.Policy,
                 StartDt = groupings.Key.StartDt,
                 EndDt = groupings.Key.EndDt,
                 Type = groupings.OrderBy(r => r.Field<string>("TYPE")).First().Field<string>("TYPE"),
                 Amount = groupings.Sum(t => t.Fields<decimal>("AMOUNT"))
              };
