    [AuthExtension]
    [SoapHeader("CredentialsAuth", Required = true)]
    [WebMethod]
    public Result<string> Add(int x, int y)
    {
        string strValue = "";
        if (CredentialsAuth.UserName == "Test" && CredentialsAuth.Password == "Test")
        {
            return new Result<string> { Value = (x + y).ToString() };
        }
        else
        {
            return new Result<string> { IsError = true, ErrorMessage = $"Unauthorized -  {SoapException.ClientFaultCode}" };
        }
    }
