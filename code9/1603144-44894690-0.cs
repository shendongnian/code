        var foodPair = new Dictionary<string, string> { { "Pizza", "Italian" }, { "Curry", "Indian" }, { "Masala", "Indian" } };
        var teamPreference = new Dictionary<string, string> { { "Jose", "Italian" }, { "John", "Indian" }, { "Sarah", "Thai" }, { "Mary", "*" } };
        var results = new List<KeyValuePair<string, string>>();
        var results2 = new string[10, 2];
        int rowIndex = 0;
        foreach (var teamMember in teamPreference)
        {
            switch (teamMember.Key)
            {
                case "Jose":
                    var key = foodPair.FirstOrDefault(x => x.Value == "Italian").Key;
                    results.Add(new KeyValuePair<string, string>(teamMember.Key, key));
                    results2[rowIndex, 0] = teamMember.Key;
                    results2[rowIndex, 1] = key;
                    rowIndex++;
                    break;
                case "John":
                    var getAll = foodPair.Where(x => x.Value == "Indian").ToList();
                    if (getAll.Any())
                    {
                        results.AddRange(getAll.Select(a => new KeyValuePair<string, string>(teamMember.Key, a.Key)));
                    }
                    foreach (var item in getAll)
                    {
                        results2[rowIndex, 0] = teamMember.Key;
                        results2[rowIndex, 1] = item.Key;
                        rowIndex++;
                    }
                    break;
                case "Sarah":
                    var c = foodPair.FirstOrDefault(x => x.Value == "Thai").Key;
                    if (!string.IsNullOrEmpty(c))
                    {
                        results.Add(new KeyValuePair<string, string>(teamMember.Key, c));
                    }
                    if (!string.IsNullOrEmpty(c))
                    {
                        results2[rowIndex, 0] = teamMember.Key;
                        results2[rowIndex, 1] = c;
                        rowIndex++;
                    }
                    break;
                case "Mary":
                    if (teamMember.Value == "*")
                    {
                        var everything = foodPair.Keys.ToList();
                        if (everything.Any())
                        {
                            results.AddRange(everything.Select(food => new KeyValuePair<string, string>(teamMember.Key, food)));
                        }
                        foreach (var item in everything)
                        {
                            results2[rowIndex, 0] = teamMember.Key;
                            results2[rowIndex, 1] = item;
                            rowIndex++;
                        }
                    }
                    break;
            }
        }
        if (results.Any())
        {
            foreach (var result in results)
            {
                Console.WriteLine("{0}, {1}", result.Key, result.Value);
            }
        }
        Console.WriteLine("Using multidimensional array");
        for (int row = 0; row < rowIndex; row++)
        {
            Console.WriteLine("{0}, {1}", results2[row, 0], results2[row, 1]);
        }
