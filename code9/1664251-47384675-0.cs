    var multipartMemoryStreamProvider= await req.Content.ReadAsMultipartAsync();
    foreach (HttpContent content in multipartMemoryStreamProvider.Contents)
    {  
       // for reading the uploaded file
       var filename= content.Headers.ContentDisposition.FileName.Trim('"');
       var stream=await content.ReadAsStreamAsync();          
       
       //for formdata, you could check whether `content.Headers.ContentDisposition.FileName` is empty
       log.Info($"name={content.Headers.ContentDisposition.Name},value={await content.ReadAsStringAsync()}");
    }
