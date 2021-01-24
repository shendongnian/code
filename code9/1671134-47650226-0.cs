     var grouping = from a in collectionOfA
                    from b in a.nestedList
                    group a by new { b.innerid, b.innername } into g
                    select new
                    {
                        innerid = g.Key.innerid,
                        innername = g.Key.innername,
                        items = g.ToList()
                    };
