    public override int GetHashCode()
    {
        var x = Math.Min(_x, _y);
        var y = Math.Max(_x, _y);
        unchecked
        {
            return (x * 397) ^ y;
        }
    }
