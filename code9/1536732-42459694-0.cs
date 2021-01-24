    public static ListHelpers
    {
        public void AddSum(this List<Dictionary<List<int>, int>> list, params int[] values)
        {
            list.Add(new Dictionary<List<int>, int> { values.ToList(), values.Sum() });
        }
    }
