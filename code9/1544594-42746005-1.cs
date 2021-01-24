    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetAllEmployeesFromEmpInPureJSON()
    {
        var vDt = GetAllEmployeesFromEmp();
        Context.Response.Write(JsonConvert.SerializeObject(vDt));
    }
