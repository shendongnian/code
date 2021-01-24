    using (HttpClient httpClient = new HttpClient())
    using (var multiPartContent = new MultipartFormDataContent())
    {
         var fileContent = new ByteArrayContent(image);
         fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
         {
             FileName = attachementname
         };
         multiPartContent.Add(fileContent);
         HttpResponseMessage response = await httpClient.PostAsync(url, multiPartContent);
                    
         Stream body = await response.Content.ReadAsStreamAsync();
         .....
    }
