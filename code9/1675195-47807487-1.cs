    private static Point2D Point2DFromString(string s, string name) {
        var userInput = Console.ReadLine();
        var match = Regex.Match(userInput, @"\(([-\d.]+),\s+([-\d.]+)\)");
        var x = Convert.ToInt32(match.Groups[1].Value);
        var y = Convert.ToInt32(match.Groups[2].Value);
        return new Point2D(x, y, name);
    }
