    public MyListComparer : IComparer<List<int>>
    {
        public int Compare(List<int> x, List<int> y)
        {
            var minLength = x.Count < y.Count ? x.Count : y.Count;
            for (var i = 0 ;i < minLength; i++)
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
            if (x.Count > y.Count)
            {
                return 1;
            }
            if (y.Count > x.Count)
            {
                return -1;
            }
            return 0;
        }
    }
