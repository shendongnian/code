    // POST api/files
    public async Task<HttpResponseMessage> Post()
    {
        // Check if the request contains multipart/form-data.
        if (!Request.Content.IsMimeMultipartContent())
        {
            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        }
        string root = HttpContext.Current.Server.MapPath("~/App_Data");
        var provider = new MultipartFormDataStreamProvider(root);
        string value;
        try
        {
            // Read the form data and return an async data.
            var result = await Request.Content.ReadAsMultipartAsync(provider);
            // This illustrates how to get the form data.
            foreach (var key in provider.FormData.AllKeys)
            {
                foreach (var val in provider.FormData.GetValues(key))
                {
                    // return multiple value from FormData
                    if (key == "value")
                        value = val;
                }
            }                       
            if (result.FileData.Any())
            {                    
                // This illustrates how to get the file names for uploaded files.
                foreach (var file in result.FileData)
                {
                    FileInfo fileInfo = new FileInfo(file.LocalFileName);
                    if (fileInfo.Exists)
                    {
                       //do somthing with file
                    }
                }
            }
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, value);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = files.Id }));
            return response;
        }
        catch (System.Exception e)
        {
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
        }
    }
