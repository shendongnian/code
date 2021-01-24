    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, Binder binder)
    {
        if (req.Method == HttpMethod.Post) 
        {
            string jsonContent = await req.Content.ReadAsStringAsync();
    
            var attributes = new Attribute[]
            {    
                new BlobAttribute("testdata/{rand-guid}.txt"),
                new StorageAccountAttribute("test_STORAGE")
            };
    
            using (var writer = await binder.BindAsync<TextWriter>(attributes))
            {
                writer.Write(jsonContent);
            }
    
            return req.CreateResponse(HttpStatusCode.OK);
        }
        else 
        {
            return req.CreateResponse(HttpStatusCode.BadRequest);    
        }
    }
