    public int[] GetValues(int a, int b, int count)
    {
        double d = (b - a) / (double)(count - 1);
        return Enumerable.Range(0, count)
           .Select(i => (int)Math.Round(a + d * i))
           .ToArray();
    }
    
