    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = @"/GetData?value={value}")]
    public string GetData(int value)
    {
        return string.Format("You entered: {0}", value);
    }
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = @"/Test")]
    public string Test()
    {
        return "test success";
    }
