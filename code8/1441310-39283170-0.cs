    public static Boolean CompareDictionary(Dictionary<string, object> D1, Dictionary<string, object> D2)
    {
        if (D1 == null && D2 == null) return true;
        else if (D1 == null || D2 == null) return false;
    
        if (D1.Count != D2.Count) return false;    
        if (D1.Keys.Except(D2.Keys).Any()) return false;
        if (D2.Keys.Except(D1.Keys).Any()) return false;
        foreach (string Key in D1.Keys)
        {
            if (!D2.ContainsKey(Key)) return false;
            if (D1[Key] != D2[Key]) return false;
        }
        return true;
    }
