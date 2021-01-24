    public static void ArrayCalledWithOrderBy(string[] origin)
       {
           var arr = (origin.OrderBy(i => i).ToArray());
           //isEqual flag is false
           var isEqual = Object.ReferenceEquals(arr, origin);
    
          DisplayArray(arr, "After orderby inside method");
       }
