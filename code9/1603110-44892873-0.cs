            var str = "|TS|170702/2300|170703/0503|42.80 -102.64 39.76 -102.64 39.44 -99.37 42.48 -99.37";  
            int itemsInGroup = 2;
            var pairs = str.Split('|')[4].Split(' ').
                        // Give each set of coordinate a group number.
                        Select((n, i) => new { GroupNumber = i / itemsInGroup, Number = n }).
                        GroupBy(n => n.GroupNumber).
                        Select(g => 
                        {
                            var coordinate = g.Select(n => n.Number).ToList();
                            return new lat_longPairs
                            {
                                latitude = decimal.Parse(coordinate[0], NumberFormatInfo.InvariantInfo),
                                longitude = decimal.Parse(coordinate[1], NumberFormatInfo.InvariantInfo),
                            };
            });
