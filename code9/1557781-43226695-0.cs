    static async Task<string> RunAsync() {
     client.BaseAddress = new Uri("http://foaas.com/");
     client.DefaultRequestHeaders.Accept.Clear();
     client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
    
     try {
      return await GetProductAsync("/because/:Insultinator");
     } catch (Exception e) {
      Console.WriteLine(e.Message);
     }
    }
