    public static void Main()
    {
        var str = new List<string>
        {
            "bla",
            "bla",
            "baum",
            "baum",
            "nudel",
            "baum",
        };
        var copy = new List<string>(str);
        var repeated = str.GroupBy(s => s).Where(group => group.Any())
            .Select(group => string.Join(" - ",
                group.Select((s, i) =>
                    Enumerable.Range(1, str.Count).Where(i2 => str[i2 - 1] == group.Key).ToList()[i])));
        var repeated2 = Repeat(str);
        var repeated3 = str.GroupBy(s => s).Where(group => group.Any())
            .Select(group =>
            {
                var indices = Enumerable.Range(1, str.Count).Where(i => str[i-1] == group.Key).ToList();
                return string.Join(" - ", group.Select((s, i) => indices[i]));
            });
        
        Console.WriteLine(string.Join("\n", repeated) + "\n");
        Console.WriteLine(string.Join("\n", repeated2) + "\n");
        Console.WriteLine(string.Join("\n", repeated3));
        Console.ReadLine();
    }
    public static List<string> Repeat(List<string> str)
    {
        var distinctItems = str.Distinct();
        var repeat = new List<string>();
        foreach (var item in distinctItems)
        {
            var added = false;
            var reItem = "";
            for (var index = 0; index < str.LongCount(); index++)
            {
                if (item != str[index]) 
                    continue;
                added = true;
                reItem += " - " + (index + 1);
            }
            if (added)
                repeat.Add(reItem.Substring(3));
        }
        return repeat;
    }
