    public SomeData GetSomeData()
    {
        if (condition) return ActualData;
        HttpContext.Response.StatusCode = 401;
        return null;
    }
