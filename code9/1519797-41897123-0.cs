    public async Task ContentAction()
    {
        var jsonString = "{\"test\":1,\"output\":false}";
        byte[] data = Encoding.UTF8.GetBytes(jsonString);
        Response.ContentType = "application/json";
        await Response.Body.WriteAsync(data, 0, data.Length);
    }
