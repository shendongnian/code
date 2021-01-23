    public override int GetHashCode()
    {
        const int prime = 131;
        int hash = A.GetHashCode();
        hash += prime;
        hash ^= B.GetHashCode();
        hash += prime;
        hash ^= (C+D).GetHashCode();
        return hash;
    }
