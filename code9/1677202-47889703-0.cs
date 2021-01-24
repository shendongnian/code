	public Dictionary<string, int> Formatsfunction(List<Metadata> mmds)
    {
        Dictionary<string, int> formatNumber = new Dictionary<string, int>();
        foreach (Metadata mmd in mmds)
        {
            var type = mmd.Format.Type;
            var found = formatNumber.ContainsKey(type);
            if (found == true)
            {
                formatNumber[type]++;
            }
            else
            {
                formatNumber[type] = 1;
            }
        }
        Console.WriteLine();
        return formatNumber;
    }
    private string MeldingInformatie(string impact, string type, List<Metadata> mmds)
    {
        var temp = Formatsfunction(mmds);
        // (String interpolation is used)
        var formats = temp.Keys.Select(type => $"{type}({temp[type]})");
        return String.Join(" ", formats);
