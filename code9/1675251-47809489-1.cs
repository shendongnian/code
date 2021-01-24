    public virtual JsonNetResult GetData(string customer, string additionalData)
    {
    	// Get data
    
        return new JsonNetResult()
        {
            Data = new
            {
                value1 = "something",
                value2 = "something"
            }
        };
    }
