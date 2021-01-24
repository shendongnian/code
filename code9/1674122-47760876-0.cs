    private List<int> GetInts()
    {
        var res = new List<int>();
        Parallel.For(0,100, i=>
        {
            lock(res)
            {
                res.Add(i);
            }
        });
        return res;
    }
