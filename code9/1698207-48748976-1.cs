    public bool IsCommonEnd(int[] a, int[] b)
    {
        ValidateArray(nameof(a), a);
        ValidateArray(nameof(b), b);
        return a.First() == b.First() || a.Last() == b.Last();
    }
