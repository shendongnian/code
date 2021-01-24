    [FunctionName("SetPoco")]
    public static async Task<IActionResult> SetPoco(
        [HttpTrigger("POST", Route = "poco/{key}")] HttpRequest request,
        [Redis(Key = "{key}")] IAsyncCollector<CustomObject> collector)
    {
        string requestBody;
        using (var reader = new StreamReader(request.Body))
        {
            requestBody = reader.ReadToEnd();
            var value = JsonConvert.DeserializeObject<CustomObject>(requestBody);
            await collector.AddAsync(value);
        }
        return new OkObjectResult(requestBody);
    }
