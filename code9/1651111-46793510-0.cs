     var res = table1.GroupBy(t => t.Status)
                .Select(g => new LastStatusDto()
                {
                    StatusId = 0,
                    StatusName = g.Key,
                    Count = g.Count(),
                    drillDownData = g.GroupBy(s => s.SubStatus)
                        .Select(st => new LastStatusChildDataDto()
                        {
                            SubStatusName = st.Key,
                            Count = st.Count()
                        })
                });
