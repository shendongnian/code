    public override int GetHashCode()
    {
        int hash = A.GetHashCode();
        hash += 131;
        hash ^= B.GetHashCode();
        hash +=131;
        hash ^= (C+D).GetHashCode();
        return hash;
    }
