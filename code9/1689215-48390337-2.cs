    var summaries = records.Select(x => new GenericRecord(x.Col1, x.Col2, x.Col3, x.GroupName))
                .GroupBy(x => x.GroupName)
                .Select(x => new {
                    GroupName = x.Key,
                    Total1 = x.Sum(y => y.ConvertedCol1),
                    Total2 = x.Sum(y => y.ConvertedCol2),
                    Total3 = x.Sum(y => y.ConvertedCol3),
                    Count = x.Count()
                }).ToList();
