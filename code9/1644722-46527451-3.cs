    public override bool Equals(object obj)
    {
        var other = obj as Bar;
        if (obj == null)
            return false;
        return other.Left == Left && other.Right == Right;
    }
    
    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + Left.GetHashCode();
            hash = hash * 23 + Right.GetHashCode();
            return hash;
        }
    }
