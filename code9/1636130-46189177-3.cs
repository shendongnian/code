    public SomeData GetSomeData()
    {
        if (condition) return ActualData;
        HttpContext.Response.StatusCode = 400;
        return null;
    }
