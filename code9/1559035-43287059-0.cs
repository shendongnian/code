    [HttpGet("/api/data")]
    public async void GetData()
    {
        await Response.Body.WriteAsync(myByteArray, 0, myByteArray.Length);
    }
