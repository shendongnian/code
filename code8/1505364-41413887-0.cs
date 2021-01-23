    private static void AddToBuilder(IList<string> parts, StringBuilder sb)
    {
        if (sb.Length > 0)
            parts.Add(sb.ToString());
    
        sb.Clear();
    }
    
    static void Main(string[] args)
    {
        string csv = "\"a,b\",\"c,d\",\"e\",\"f\",g,h,i";
        var parts = new List<string>();
        bool innerString = false;
        var sb = new StringBuilder();
        foreach (var c in csv)
        {
            if (c == '\"')
            {
                if (innerString)
                    AddToBuilder(parts, sb);
    
                innerString = !innerString;
                continue;
            }
    
            if (c == ',' && !innerString)
            {
                AddToBuilder(parts, sb);
                continue;
            }
    
            sb.Append(c);
        }
    
        AddToBuilder(parts, sb);
