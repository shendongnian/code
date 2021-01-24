    /// <summary>
    /// Uploads the photo.
    /// </summary>
    /// <returns>The photo.</returns>
    /// <param name="photoBytes">Photo bytes.</param>
    public async Task<bool> UploadPhoto(byte[] photoBytes, int PropertyId, string fileName)
    {
        bool rtn = false;
    
        var content = new MultipartFormDataContent();
        var fileContent = new ByteArrayContent(photoBytes);
        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
        fileContent.Headers.ContentDisposition = 
                             new ContentDispositionHeaderValue("attachment") {
            FileName = fileName + ".jpg"
        };
        content.Add(fileContent);
        fileContent.Headers.ContentDisposition.Parameters.Add(
                             new NameValueHeaderValue("<otherParam>", "<otherParamValue>"));
    
        string url = RestURL() + "Pictures/Put";
        try
        {
            using (var client = new HttpClient())
            {
                // add an authotization token if you have one
                //client.DefaultRequestHeaders.Add("authenticationToken", "yourToken");
                await client.PutAsync(url, content);
                rtn = true;
            }
        }
        catch (Exception ex)
        {
        }
    
        return rtn;
    }
