    using System.Linq; // top of code file
    public int MaxFirst(params int[][] intArrays)
    {
        return intArrays.Where(x => x != null && x.Length > 0).Max(x => x[0]);
    }
