    public static async void Run(
                [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]
                HttpRequest req,
                ILogger log)
            {
                var content = await new StreamReader(req.Body).ReadToEndAsync();
    
                MyClass myClass = JsonConvert.DeserializeObject<MyClass>(content);
                
            }
