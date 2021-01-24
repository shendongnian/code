    public SomeData GetSomeData()
    {
        if (condition) return myData;
        else 
        {
            HttpContext.Response.StatusCode = 401;
            return null;
        }
    }
