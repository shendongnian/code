    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public List<Checker_DuplicateUAMNumberDetails> Checker_DuplicateUAMNumber(string csp,string firstName,string middleName,string lastName,int mode)
    {
        /* 
        ADO.NET preparation and executions removed for brevity 
        */
        var result = new List<Checker_DuplicateUAMNumberDetails>;
        foreach (DataRow row in table.Rows)
        {
            result.Add(
                new Checker_DuplicateUAMNumberDetails
                { 
                    uamnumber = row["UAM #"].ToString()
                }
            );
        }
        return result;
    }
