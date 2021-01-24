    [HttpGet]
    public HttpResponseMessage Get(string parameterOne, string parameterTwo)
    {
        var response = new VoiceResponse()
            .Redirect(
                url: $"https://example.com/Gather?paramaterOne={parameterOne}&parameterTwo={parameterTwo}",
            method: "POST");
        var content = new StringContent(response.ToString(), Encoding.UTF8, "application/xml");
        return new HttpResponseMessage
        {
            Content = content,
            StatusCode = HttpStatusCode.OK
        };
    }
