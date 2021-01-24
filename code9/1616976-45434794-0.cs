    [HttpGet("bin")]
    public async Task Data()
    {
        var data = Encoding.UTF8.GetBytes("Hello world");
        Response.Headers.Add(new KeyValuePair<string, StringValues>("Content-Type", "application/octet-stream"));
        Response.StatusCode = 400;
        await Response.Body.WriteAsync(data, 0, data.Length);
    }
