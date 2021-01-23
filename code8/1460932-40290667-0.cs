    public static async Task RunAsync(BrokeredMessage message, TraceWriter log) {
        var body = message.GetBody<string>();
    
        using (var client = new HttpClient()) {
            var content = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("http://some-rest-endpoint.url/api", content);
            if (!response.IsSuccessStatusCode) {
                log.Warning("Message could not be sent");
                await message.AbandonAsync();
            }
        }    
    }
