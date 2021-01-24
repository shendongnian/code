    [WebMethod]
    public static object bubblesort(int[] arr)
    {
        // ----------------------------------------
        // --- Return a Lit of int
        // ----------------------------------------
        // var sra = arr.ToList();
        // sra.Sort();
        // return sra;      
        
        // ----------------------------------------
        // --- Return a List of string
        // ----------------------------------------
        // return sra.Select(i => i.ToString()).ToList();
                  
        // ----------------------------------------
        // --- Return a string containing all numbers sorted
        var sra = arr.ToList();
        sra.Sort();
        return String.Join("", sra.Select(i => i.ToString()));
    }
