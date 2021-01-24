    public void Post([FromBody]Class1 value)
    {
        if(value!=null)
        {
           var stringVersion = value.ToString();
        } 
    }
