    [WebMethod]
    public string Test()
    {
        // You can grab the ID as optional parameter from the request
        int optionalID = 0;
        Int32.TryParse(this.Context.Request["optionalID"], out optionalID);
        return "Test " + optionalID;
    }
