    class Test
    {
        public int Value;
        public static bool operator ! (Test item)
        {
            return item.Value != 0;
        }
    }
