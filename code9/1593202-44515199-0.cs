        public static bool SomeRange(int value,int start,int end)
        {
            return (value > start && value < end);
        }
        static void Main()
        {
            List<int> valueList = new List<int> { 1,65,3,76,34,23,11,5,665,334};
            var result = valueList.Where(x => SomeRange(x, 0, 30)).Count();
        }
