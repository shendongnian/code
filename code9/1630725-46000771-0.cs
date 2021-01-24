     HttpClient httpClient = new HttpClient();
     MultipartFormDataContent form = new MultipartFormDataContent();
     FileStream fs = System.IO.File.OpenRead("your file path");
     var streamContent = new StreamContent(fs);
     var imageContent = new ByteArrayContent(streamContent.ReadAsByteArrayAsync().Result);
     imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
     form.Add(imageContent, "image", Path.GetFileName("your file name"));
     var response = httpClient.PostAsync("apiurl", form).Result;
