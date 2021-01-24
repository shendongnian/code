    public int CompareTo(RenderObject other)
    {
        // Z sort if y is equal. [High to low]
        if (y == other.y)
        {
            z.CompareTo(other.z); // <<== This line has no effect on sorting
        }
        // Default to y sort. [High to low]
        return other.y.CompareTo(y);
    }
