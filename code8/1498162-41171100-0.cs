    private List<string> SpecialSort(string[] all, string[] pref)
    {
        List<string> listed = all.ToList();
        listed.Sort();
        foreach (string s in pref.Reverse())
            if (listed.Contains(s))
            {
                listed.Remove(s);
                listed.Insert(0, s);
            }
        return listed;
    }
