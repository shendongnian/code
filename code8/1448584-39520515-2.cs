    public void POSTDataHttpContent(string jsonString, string webAddress)
    {
        var Task = Task<HttpResponseMessage>.Run(async () => {
            using (HttpClient client = new HttpClient())
            {
                StringContent stringContent = new StringContent(jsonString);
                HttpResponseMessage response = await client.PostAsync(
                    webAddress,
                    stringContent);
               
                return response;
            }
        });
        Task.Wait();
        Assert.IsNotNull(Task.Result);
    }
