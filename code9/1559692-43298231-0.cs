	//create http client
	using (var client = new HttpClient())
	{
		//create the content we need
		using (var multipartFormDataContent = new MultipartFormDataContent())
		{
			//read the file as bytes
			var bytes = //file content
			//wrap it into the formdata
			multipartFormDataContent.Add(new ByteArrayContent(bytes));
			
			//do the post request and retrieve the response from the server
			var result = await client.PostAsync("myUrl.com", multipartFormDataContent);
		}
	}
