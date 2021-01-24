    public static int? NullableSum( this IEnumerable<int?> source)
    {
        int? sum = null;
        foreach (int? v in source)
        {
            if (v != null)
            {
                if (sum == null)
                {
                    sum = 0;
                }
 
                sum += v.GetValueOrDefault()               
            }
        }
        
        return sum;
    }
     
