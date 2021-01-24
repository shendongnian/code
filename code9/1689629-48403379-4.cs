    public bool HasInverse
    {
        get
        {
            return !DoubleUtil.IsZero(Determinant);
        }
    }
