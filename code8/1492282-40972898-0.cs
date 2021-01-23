     using (var formData = new MultipartFormDataContent())
     {
        var bytes = File.ReadAllBytes(file);
         formData.Add(new StreamContent(new MemoryStream(bytes)), "file", file);
         HttpResponseMessage responseFile = client.PostAsync("ReportInfo/SaveFile?docId=" + docId, formData).Result;
     }
