        List<string> newDictKeys = new List<string> { "12323", "432234", "45345435" };
        Queue<string> t = new Queue<string> (new []{ "dfgdfg", "asdfds", "wertert" });
        Queue<string> t2 = new Queue<string>(new[] { "ZCxzcx", "xcvbcvb", "gfhjfgj" });
        Dictionary<string, List<string>> dict = newDictKeys
        .Where(key => t.Count > 0 && t2.Count > 0)
        .ToDictionary(key => key, key => new List<string> {t.Dequeue(), t2.Dequeue()});
