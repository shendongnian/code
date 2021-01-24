    public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
    {
            int n = list.Count-1;
            while(n != 0)
            {
                for (int i = 0; i <= list.Count-1 ; i++)
                {
                    if (list[n] + list[i] == sum)
                    {
                        return Tuple.Create(i, n);
                    }
                }
                n--;
            }
            return null;
    }
