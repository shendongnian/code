    public async Task<HttpResponseMessage> GetFunction(string SQLstring)
    {
            HttpResponseMessage response = new HttpResponseMessage()
            {
                Content = new StringContent(await SQLFunctions.SQLsyncFunctionGet(SQLstring), System.Text.Encoding.UTF8, "application/json")
            };
            return response;
    }
