    [WebMethod]
    public static object bubblesort(int[] arr)
    {
        var sra = arr.ToList();
        sra.Sort();
        return sra;
    }
