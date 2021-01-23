    public static Dictionary<IEnumerable<string>,IEnumerable<IEnumerable<string>>> Parse(IEnumerable<IEnumerable<string>> input)
    {
        IEnumerable<string> key = null;
        var rows = new List<IEnumerable<string>>();
        var result = new Dictionary<IEnumerable<string>,IEnumerable<IEnumerable<string>>>();
        
        foreach(var row in input)
        {
            if(row.First().StartsWith("Period"))
            {
                if(key != null)
                    result.Add(key,rows.AsEnumerable());
                
                key = row;
                rows = new List<IEnumerable<string>>();
            }
            else
            {
                rows.Add(row);
            }
        }
        result.Add(key,rows);
        return result;
    }
