    static void Main()
    {
         foreach(int i in multi(30, new []{2,3,4,5,7} ))
            Console.Write(i+", ");
    }
    
    static List<int> multi(int max, int[] divs)
    {
        int[] deltas = calcDeltas(divs);
        
        List<int> result = new List<int>();
        
        int j = 1;
        for(int i = deltas[0]; i<=max; i+=deltas[j++%deltas.Length])
        {
            result.Add(i);
        }
        
        return result;
    }
    
    static int[] calcDeltas(int[] divs)
    {
        long max = 1;
        foreach(int div in divs)
            max = lcm(max,div);
    
        List<long> ret = new List<long>();
    
        foreach(int div in divs)
        {
            for(int i=div; i<=max; i+=div)
            {
                int idx = ret.BinarySearch(i);
                if (idx < 0)
                {
                    ret.Insert(~idx, i);
                }
            }
        }
        for(int i=ret.Count-1; i>0; i--)
            ret[i]-=ret[i-1];
    
        return ret.ConvertAll(x => (int)x).ToArray();
    }
    
    static long gcf(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    
    static long lcm(long a, long b)
    {
        return (a / gcf(a, b)) * b;
    }
