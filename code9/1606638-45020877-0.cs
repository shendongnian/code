    [HttpGet("myobject")]
    public MyObject GetMyObject()
    {
        return new MyObject()
        {
            Date = LocalDate.FromDateTime(DateTime.Now),
            AnotherProperty = "A string"
        };
    }
