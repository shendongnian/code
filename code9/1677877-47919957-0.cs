    var test = new[] {"a 2", "a 10", "a"};
    var sorted = test.OrderBy(s => new string(s.Where(char.IsLetter).ToArray())).ThenBy(s =>
    {
        var stringNumber = Regex.Match(s, @"\d+").Value;
        return string.IsNullOrEmpty(stringNumber) ? 0 : int.Parse(stringNumber);
    });
