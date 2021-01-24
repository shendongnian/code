    private string FilePath { get; set; }
    private string[] ReadFile()
    {
        return File.ReadAllLines(FilePath);
    }
    public Dictionary<Tuple<string, string>, string> MakeOrIncSeedValuesFromCsv(string[] lines)
    {
        var valuePairToSeedValue = new Dictionary<Tuple<string, string>, string>();
        var lines = ReadFile();
        for (int i = 0; i < lines.Length; i++)
        {
            var values = lines[i].Split(',');
            if (values.Length > 2)
            {
                var newSeedValue = IncSeedValue(lines[2]);
                var key = Tuple.Create<string, string>(values[0], values[1]);
                if (!valuePairToSeedValue.ContainsKey(key))
                {
                    valuePairToSeedValue.Add(key, newSeedValue);
                }
                else
                {
                    valuePairToSeedValue[key] = newSeedValue;
                }
            }
            else
            {
                var key = Tuple.Create<string, string>(values[0], values[1]);
                var seed = GetSeedValue(key);
                if (!valuePairToSeedValue.ContainsKey(key))
                {
                    valuePairToSeedValue.Add(key, seed);
                }
                else
                {
                    valuePairToSeedValue[key] = seed;
                }
            }
        }
        return valuePairToSeedValue;
    }
    private string GetSeedValue(Tuple<string, string> values)
    {
        return // put your code here
    }
    private string IncSeedValue(string actualSeedValue)
    {
        return // put your code here
    }
}
