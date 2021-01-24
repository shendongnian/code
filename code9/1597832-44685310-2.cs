    public static void ShuffleTheSameWay<T>(this IList<T> list)  
    {  
        Random rng = new Random(0);  
        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = rng.Next(n + 1);  
            T value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }  
    }
