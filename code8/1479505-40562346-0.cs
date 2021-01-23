    public MyListComparer : IComparer<List<int>>
    {
        public int Compare(List<int> x, List<int> y)
        {
            var minLength = x.Length < y.Length? x.Length : y.Length;
            for (var i = 0 ;i < x.minLength; i++)
            {
                if (x[i] > y[i])
                {
                    return 1;
                }
                if (x[i] < y[i])
                {
                    return -1;
                }
            }
            if (x.Length > y.Length)
            {
                return 1;
            }
            if (y.Length > x.Length)
            {
                return -1;
            }
            return 0;
        }
    }
