    public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
    {
        if (list.Count < 2) { return null; }
        foreach (int i in list)
        {
            int result = sum - i;
            if(list.Contains(result))
            {
                return new Tuple<int, int>(i, result);
            }
        }
        return null;
    }
