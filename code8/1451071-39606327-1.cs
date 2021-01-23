        var variables = new Dictionary<int, string[]>();
        variables.Add(0, new string[] { "Never gonna give you up", "Rick Astley", "1990", "Troll" });
        variables.Add(1, new string[] { "Together forever", "Rick Astley", "1990", "Pop" });
        variables.Add(2, new string[] { "99 Red Balloons", "Nena", "1998", "German" });
        variables.Add(3, new string[] { "Can't get you out of my head", "Kylie Minogue", "1995", "Pop" });
        foreach (var variable in variables.Where(v => v.Value.Contains("Rick Astley")))
        {
            foreach (var text in variable.Value)
            {
                Console.Write($"{text}, ");
            }
            Console.WriteLine();
        }
        Console.Read();
