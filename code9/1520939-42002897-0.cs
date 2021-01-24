    [HttpPost]
    [ActionName("GetResult")]
    public ResultObjekt GetResult([FromBody]FormularData values)
    {
        var result = values.GetType()
                         .GetProperties()
                         .ToDictionary(pi => pi.Name, pi => (string)pi.GetValue(values));
    }
