    [WebMethod]
    [ScriptMethod(UseHttpGet = true)]
    public int getSum(int a, int b)
    {
        return (a + b);
    }
    
    [WebMethod]
    public string getName(string code)
    {
        return code;
    }
