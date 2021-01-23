    var result = filteredLine
            .GroupBy(c => c.Fid)
            .Select(g => new ElmLine()
            {
                Id = g.Key,
                CoordList = g
                    .Select(c => { c.CoordX, c.CoordY })
                    .Distinct()
                    .Select(c => new CoordList() 
                            { XCord = c.CoordX, YCord = c.CoordY })
                    .ToList(),
            }).ToList();
