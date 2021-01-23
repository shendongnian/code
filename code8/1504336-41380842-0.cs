    public static class Helper
    {        
        public static void Update<T>(BasePage<T> page) where T : struct, IComparable
        {
            page.Update();
        }
    }
