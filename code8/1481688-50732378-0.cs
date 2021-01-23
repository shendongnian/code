     // read the file content without copying to local disk and write the content byte to file 
           try
           {
               var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
               JavaScriptSerializer json_serializer = new JavaScriptSerializer();
               foreach (var stream in filesReadToProvider.Contents)
               {
                   
                   //getting of content as byte[], picture name and picture type
                   var fileBytes = await stream.ReadAsByteArrayAsync();
                   var fileName = stream.Headers.ContentDisposition.Name;
                   
                   var pictureName = stream.Headers.ContentDisposition.FileName;
                   var contentType = stream.Headers.ContentType.MediaType;
                   var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/Upload/"), json_serializer.Deserialize<string>(pictureName));
                   File.WriteAllBytes(path, fileBytes);
               }
               return Request.CreateResponse(HttpStatusCode.OK);
           }catch(Exception ex)
           {
               return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
           }
