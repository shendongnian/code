    public int[] Concat(int x, int[] y)
    {
        var z = new int[x.Length + y.Length];
        x.CopyTo(z, 0);
        y.CopyTo(z, x.Length);
    
        return z;
    }
