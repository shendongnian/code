    List<int> values = new List<int>();
    public int UniqueRandomInt(int min, int max)
    {
        int val = Random.Range(min, max);
        while(values.LastOrDefault() == val)
        {
            val = Random.Range(min, max);
        }
        values.Add(val);
        return val;
    }
