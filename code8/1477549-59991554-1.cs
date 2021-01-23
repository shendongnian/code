    [HttpPost("")]
    [ReadRequestBodyIntoItems]
    [Consumes("application/json")]
    public async Task<IActionResult> ReceiveSomeData([FromBody] MyJsonObjectType value)
    {
        val bodyString = HttpContext.Items["request_body"];
        // use the body, process the stuff...
    }
