     var uploadPath = HostingEnvironment.MapPath("/") + @"/Uploads";
     Directory.CreateDirectory(uploadPath);
     var provider = new MultipartFormDataStreamProvider(uploadPath);
     await Request.Content.ReadAsMultipartAsync(provider);
    
     // Files
     //
     foreach (MultipartFileData file in provider.FileData)
     {
         Debug.WriteLine(file.Headers.ContentDisposition.FileName);
         Debug.WriteLine("File path: " + file.LocalFileName);
     }
    
     // Form data
     //
     foreach (var key in provider.FormData.AllKeys)
     {
         foreach (var val in provider.FormData.GetValues(key))
         {
              Debug.WriteLine(string.Format("{0}: {1}", key, val));
         }
     }
