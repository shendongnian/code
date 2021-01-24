        List<string> newDictKeys = new List<string> { "12323", "432234", "45345435" };
        List<string> t = new List<string> { "dfgdfg", "asdfds", "wertert" };
        List<string> t2 = new List<string> { "ZCxzcx", "xcvbcvb", "gfhjfgj" };
        Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
        foreach (var key in newDictKeys.Where(key => t.Count > 0 && t2.Count > 0))
        {
            dict.Add(key, new List<string> {t.FirstOrDefault(), t2.FirstOrDefault()});
            t.RemoveAt(0);
            t2.RemoveAt(0);
        }
