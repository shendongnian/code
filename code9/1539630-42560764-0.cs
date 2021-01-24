    return dataTable.AsEnumerable()
                .GroupBy(x => x.Id)
                .Select(x => new
                {
                    id = x.Key,
                    name = x.Key,
                    cardTypes = x.Select(t => new
                    {
                        name = t.Name,
                        exp = t.Exp
                    })
                });
