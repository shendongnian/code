    /// <summary>
    /// Bottom Property - This is a read-only alias for Y + Height
    /// If this is the empty rectangle, the value will be negative infinity.
    /// </summary>
    public double Bottom
    {
        get
        {
            if (IsEmpty)
            {
                return Double.NegativeInfinity;
            }
        return _y + _height;
        }
    }
