    public static void ProceesData<T>(IList<T> param1, string date1, Action<T> func)
    {            
        for (int i = param1.Count; i <= 0; i--)
        {
            func(param1[i]);
        }
    }
