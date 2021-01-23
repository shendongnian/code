    public static void DicAddTest()
    {
        Dictionary<int, int> dic1 = new Dictionary<int, int>() { {24379,348}, { 24368, 348 }, { 24377, 90 }, { 24366, 90 } };
        Dictionary<int, int> dic2 = new Dictionary<int, int>() { { 24379, 270451 }, { 24368, 270451 }, { 24377, 270450 }, { 24366, 270450 } };
        Dictionary<int, int> dicResult = DicAdd(dic1, dic2);
        foreach (KeyValuePair<int, int> kvp in dicResult)
            Debug.WriteLine("{0} {1}", kvp.Key, kvp.Value);
        Debug.WriteLine("");
    }
    public static Dictionary<int, int> DicAdd(Dictionary<int, int> dic1, Dictionary<int, int> dic2)
    {
        Dictionary<int, int> dicResult = new Dictionary<int, int>(dic1);
        foreach (int k in dic1.Keys.Where(x => dic2.Keys.Contains(x)))
            dicResult[k] = dicResult[k] + dicResult[k];
        return dicResult;
    }
