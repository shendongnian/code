    static string Compact(double d)
    {
        var s = d.ToString("G");
        if(s.Contains("E-0") || s.Contains("E+0"))
        {
            s = Regex.Replace(s, @"(\d+)(E[+-])0+(\d+)", "$1$2$3");
        }
        return s;
    }
