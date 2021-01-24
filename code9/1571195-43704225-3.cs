    public static void WriteColoredLine(string formattedString, params (object, ConsoleColor)[] pars)
    {
        var pattern = "[{]\\d[}]";
        var splitted = Regex.Split(formattedString, pattern);
        var formatItems = Regex.Matches(formattedString, pattern).Cast<Match>().Select(m => int.Parse(m.Value.Trim('{', '}'))).ToList();
        for (var i = 0; i < splitted.Length - 1; i++)
        {
            Console.Write(splitted[i]);
            Console.BackgroundColor = pars[formatItems[i]].Item2;
            Console.Write(pars[formatItems[i]].Item1);
            Console.BackgroundColor = ConsoleColor.Black;
        }
        Console.WriteLine(splitted.Last());
    }
