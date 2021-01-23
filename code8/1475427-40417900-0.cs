    var bodyContent = new StringContent("");
    bodyContent.Headers.Add("Content-Range", "bytes */*");
    
    var progressRequest = await uploadClient.PutAsync(uploadLink.PathAndQuery, bodyContent);
    var progressResult = await progressRequest.Content.ReadAsStringAsync();
