    [Route("/test")]
    [HttpPost]
    public async Task Test()
    {
       using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
       {
          var textFromBody = await reader.ReadToEndAsync();                    
       }            
    }
