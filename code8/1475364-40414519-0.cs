        static void Main(string[] args)
        {
            var gap = 0;
            gap = GetGap(new int[] { 0, 1, 5, 7 });//2
            gap = GetGap(new int[] { 0, 1, 2, 3, 4 });//5
            gap = GetGap(new int[] { 1, 2, 3, 4 });  //0
            gap = GetGap(new int[] { -2, -1, 1, 2, 3, 4 });  //0
            gap = GetGap(new int[] { -2, -1, 0, 1, 2, 3, 4 });  //0
            gap = GetGap(new int[] { 0 });  //1
            gap = GetGap(new int[] {});  //0
        }
        private static int GetGap(int[] items)
        {
            if (!items.Any()) return 0;
            if (items.First() != 0) return 0;
            int counter = 0;
            return items.ToList().LastOrDefault(x => x == counter++)+1; 
        }
