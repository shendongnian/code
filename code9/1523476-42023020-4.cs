    [WebMethod]
    public static object bubblesort(int[] arr)
    {
        var sra = arr.ToList();
        sra.Sort();
        
        // If you want to return a List of string
        // return sra.Select(i => i.ToString()).ToList();
        return sra;
    }
