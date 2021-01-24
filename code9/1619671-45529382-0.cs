    public static void ArrayCalledWithOrderBy(string[] arr)
    {
        arr = (arr.OrderBy(i => i).ToArray()); 
        DisplayArray(arr, "After orderby inside method");
    }
