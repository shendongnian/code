    public async Task<string> FunctionHandler(string input, ILambdaContext context)
    {
        try
        {
            using (AmazonLambdaClient client = new AmazonLambdaClient(RegionEndpoint.USEast1))
            {
                JObject ob = new JObject { { "param", "hello" }, { "param1", "Lambda" } };
    
                var request = new InvokeRequest
                {
                    FunctionName = "Function1",
                    Payload = ob.ToString()
                };
    
                var response = await client.InvokeAsync(request);
    
                using (var sr = new StreamReader(response.Payload))
                {
                    return await sr.ReadToEndAsync();
                }
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
