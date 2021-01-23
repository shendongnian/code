    [HttpPost("")]
    [Consumes("application/json")]
    public async Task<IActionResult> ReceiveSomeData()
    {
        using (var reader = new StreamReader(
               Request.Body,
               encoding: Encoding.UTF8,
               detectEncodingFromByteOrderMarks: false
        ))
        {
            var bodyString = await reader.ReadToEndAsync();
            var value = JsonConvert.DeserializeObject<MyJsonObjectType>(bodyString);
            // use the body, process the stuff...
        }
    }
