    private static void Merge(Regions region, Regions region2)
    {
        List<List<string>> splittedLists = region.ParentName.Select(p => p.Split(new char[] { ',' }, StringSplitOptions.None).ToList()).ToList();
        List<List<string>> splittedLists2 = region2.ParentName.Select(p => p.Split(new char[] { ',' }, StringSplitOptions.None).ToList()).ToList();
        List<string> res = new List<string>();
    
        foreach (var s in splittedLists)
        {
            bool wasMatch = false;           
            foreach (var ss in s)
            {
                bool contains = false;
                foreach (var s2 in splittedLists2.Where(s2 => s2.Contains(ss)))
                {
                    wasMatch = true;
                    contains = true;
                    res.Add(string.Join(",", s.Concat(s2).Distinct()));
                }    
                if (contains)
                {
                    contains = false;
                    break;
                }
            }    
            if (!wasMatch)
            {
                res.Add(string.Join(",", s));
            }
        }    
        region.ParentName = res.ToArray();
    }
