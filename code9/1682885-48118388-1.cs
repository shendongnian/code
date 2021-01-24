    public (int Count, string Hello) GetDataTuple()
    {
        return (1, "world");
    }
    public object GetDataObject()
    {
        return new { Count = 1, Hello = "World" };
    }
