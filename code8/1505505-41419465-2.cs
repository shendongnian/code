    public static Dictionary<int, int> DicAdd2(Dictionary<int, int> dic1, Dictionary<int, int> dic2)
    {
        Dictionary<int, int> dicResult = new Dictionary<int, int>();
        foreach (KeyValuePair<int, int> kvp in dic1.Where(x => dic2.Keys.Contains(x.Key)))
            dicResult.Add(kvp.Key, 2 * kvp.Value);
        return dicResult;
    }
