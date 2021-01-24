    static Dictionary<int, Dictionary<int, int>> CreateYearMonthTable()
    {
        var year = DateTime.Now.Year + 5;
        return Enumerable
            .Range(2008, year - 2008 + 1)
            .ToDictionary(
                y => y,
                y => Enumerable.Range(1, 12).ToDictionary(i => i, i => 0));
    }
