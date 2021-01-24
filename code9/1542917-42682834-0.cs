    var client = new HttpClient();
    var image = File.ReadAllBytes("c:\\test.png");
	var formData = new MultipartFormDataContent();
	formData.Add(new StreamContent(new MemoryStream(image)), "name","fileName.png");
    formData.Add(new StringContent("content"), "name");
	var response = client.PostAsync("http://localhost:5001/api/someMethod", formData).Result;
	if (!response.IsSuccessStatusCode)
		{
		 Console.WriteLine(response.StatusCode);
		}
		else
		{
		 var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
		 Console.WriteLine(content);
		}
