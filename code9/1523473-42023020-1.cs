    [WebMethod]
    public static object bubblesort(string arr)
    {
        // Split then convert to List<int>
        var sra = arr.Split(',').Select(int.Parse).ToList();
        // Sort the List
        sra.Sort();
        return sra;
    }
