            // ### Part 1 ###
            var combinedLineParts = filteredLine.GroupBy(c => new { c.Fid, c.FidPart})
                    .Select(g => new ElmLine()
            {
                Fid = g.Select(c => c.Fid).First(),
                FidPart = g.Select(c => c.FidPart).First(),
                CoordList = g.Select(c => new CoordList() 
                                              {XCord = c.CoordX, YCord = c.CoordY}).ToList()
                             .GroupBy(x => new {x.XCord, x.YCord})
                             .Select(x => x.First()).ToList(),
            }).ToList();
            
            // ### Part 2 ###
            foreach (var group in combinedLineParts.GroupBy(c => c.Fid))
            {
                List<List<CoordList>> coordList = group.Select(c => c.CoordList).ToList();
                if (coordList.Count > 2)
                {
                    int[] startPoint = FindStartPoint(coordList);
                    // if start point is not on top of the list, 
                    // move it to the top (to: {0,0})
                    if (startPoint[0] > 0 || startPoint[1] > 0)
                    {
                        SwapElements(coordList, startPoint, new int[] { 0, 0 });
                    }
                    // Rearange List to sort the lineparts
                    int groupNumb = 0;
                    while (groupNumb < coordList.Count - 1)
                    {
                        RearrangeList(coordList, groupNumb, group.Key);
                        groupNumb++;
                    }
                }
            // ### Part 3 ###
                // create a new list with the sorted lineparts
                combinedLines.Add( new ElmLine()
                    {
                        Fid = group.Key,
                        CoordList = coordList.SelectMany(d => d)
                                             .Select(c => new {c.XCord, c.YCord})
                                             .Distinct()
                                             .Select(c => new CoordList() 
                                                {XCord = c.XCord, YCord = c.YCord}).ToList(), 
                    });
            }
            return combinedLines;
