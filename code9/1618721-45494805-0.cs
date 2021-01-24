    public static long[] Digitize(long n)
    {
        var reversed = n.ToString().Reverse().Select(x => long.Parse(x.ToString())).ToArray();
        return reversed;
    }
