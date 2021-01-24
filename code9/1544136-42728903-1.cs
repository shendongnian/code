    using (var client = new HttpClient())
    {
      var content = new MultipartFormDataContent("acrcloud***copyright***2015***8d467c7c10a7062");
      content.Add(new StringContent("value"), "key");
      content.Add(new StreamContent(stream)
      {
        Headers =
        {
          ContentDisposition = new ContentDispositionHeaderValue(DispositionTypeNames.Attachment) { Filename = "Filename.txt" }
        }
      }, "filekey");
      await PostAsync("http://www.example.com", content);
    }
