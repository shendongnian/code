    public int CompareTo(Fence other)
    {
        int c = Post[0].CompareTo(other.Post[0]);
        if (c == 0)
             c = Post[1].CompareTo(other.Post[1]);
        return c;
    }
