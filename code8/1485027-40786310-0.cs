           var result = (from a in (from b in filledTable join c in distinctList on b[0].SerialNumber equals c.Field<string>("SERIAL NUMBER") select new { b, c })
                          group a by new { a.b[0].SerialNumber } into d
                          select new
                          {
                              Id = d.Select(x => x.b[0].Id),
                              SerialNumber = d.Select(x => x.b[0].SerialNumber),
                              ImportTable = d.Select(w => w.c.Table.AsEnumerable()
                              .Where(y=>y.Field<string>("SERIAL NUMBER") == d.Key.ToString())
                              .GroupBy(y => y.Field<string>("SERIAL NUMBER")).Select(z => z.First()))
                          });
