    var summaries = records.Select(x => new GenericRecord
                {
                    ConvertedCol1 = float.Parse(x.Col1),
                    ConvertedCol2 = float.Parse(x.Col2),
                    ConvertedCol3 = float.Parse(x.Col3),
                    GroupName = x.GroupName
                })
                .GroupBy(x => x.GroupName)
                .Select(x => new {
                    GroupName = x.Key,
                    Total1 = x.Sum(y => y.ConvertedCol1),
                    Total2 = x.Sum(y => y.ConvertedCol2),
                    Total3 = x.Sum(y => y.ConvertedCol3),
                    Count = x.Count()
                }).ToList();
