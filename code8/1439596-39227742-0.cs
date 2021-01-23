    [WebMethod(Messagename="Test1")]
    public string Test()
    {
        return "Test";
    }
    
    [WebMethod(MessageName="Test2")]
    public string Test(int ID)
    {
        return "Test " + ID;
    }
