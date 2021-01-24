    public object GetObj(object value)
    {
        if (value == null)
        {
            throw new InvalidOperationException("Cannot call with null");
        }
    }
