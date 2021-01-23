    var sortedList = a.OrderBy(x => PadNumbers(!x.Contains("M")? "" : x.Substring(x.IndexOf('M'), (x.Length - x.IndexOf('M'))))).ToList();
        
    public static string PadNumbers(string input)
    {
        return Regex.Replace(input, "[0-9]+", match => match.Value.PadLeft(10, '0'));
    }
