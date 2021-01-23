    public override int GetHashCode()
    {
        // Check that an existing code hasn't already been returned
        return new { A, B, C + D }.GetHashCode();
    }
