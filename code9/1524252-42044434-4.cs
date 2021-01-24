    public static  IEnumerable<string> Produce()
    {
        int i = 1;
        while (true)
        {
            foreach(var c in produceAmount(i))
            {
                yield return c;
            }
            i++;
        }
    }
        
    private static IEnumerable<string> produceAmount(int i)
    {
        var firstRow = Enumerable.Range('A', 'Z' - 'A'+1).Select(x => ((char)x).ToString());
        if (i >= 1)
        {
            var second = produceAmount(i - 1);
            foreach (var c in firstRow)
            {
                foreach (var s in second)
                {
                    yield return c + s;
                }
            }
        }
        else
        {
            yield return "";
        }
     }
