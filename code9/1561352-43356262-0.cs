        var lines = new List<string>();
        lines.Add("abc, 8");
        lines.Add("qwerty, 2");
        lines.Add("lplo, 5");
        lines.Add("abc, 15");
        var nameAndRanks = new Dictionary<string, int>();
        foreach(var line in lines)
        {
            var values = line.Split(',');
            var name = values[0];
            var rank = int.Parse(values[1]);
            if (nameAndRanks.ContainsKey(name))
            {
                if (nameAndRanks[name] < rank)
                {
                    nameAndRanks[name] = rank;
                }
            } else
            {
                nameAndRanks.Add(name, rank);
            }
        }
        foreach (KeyValuePair<string, int> entry in nameAndRanks)
        {
            Console.WriteLine(entry.Key + " : " + entry.Value  );
        }
