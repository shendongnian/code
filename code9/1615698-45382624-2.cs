    public async Task Post(string fileName)
    {    static void Main(string[] args)
    {
        RestRequest request = new RestRequest("values?fileName=test.pdf", Method.POST);
    
        request.AddParameter("application/pdf", File.ReadAllBytes(@"C:\Temp\upload.pdf"), ParameterType.RequestBody);
    
        var client = new RestClient(new Uri("http://localhost:55108/api"));
    
        var response = client.Execute(request);
    
        Console.ReadLine();
    }
        var file = await this.Request.Content.ReadAsByteArrayAsync();
        File.WriteAllBytes($"C:\\Uploaded\\{fileName}",file);
    }
