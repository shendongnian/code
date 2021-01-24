    /// <summary>
    /// Receiving an image across WebAPI
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    public HttpResponseMessage Put()
    {
        var result = new HttpResponseMessage(HttpStatusCode.OK);
    
        if (Request.Content.IsMimeMultipartContent())
        {
            try
            {
                Request.Content.LoadIntoBufferAsync().Wait();
                Request.Content.ReadAsMultipartAsync<MultipartMemoryStreamProvider>(
                    new MultipartMemoryStreamProvider()).ContinueWith((task) => {
                    MultipartMemoryStreamProvider provider = task.Result;
                    foreach (HttpContent content in provider.Contents)
                    {
                        Stream stream = content.ReadAsStreamAsync().Result;
                        Image image = Image.FromStream(stream);
    
                        try
                        {
                            string filename = string.Format("{0}{1}{2}{3}", 
                                                            DateTime.Now.Year, 
                                                            DateTime.Now.Month, 
                                                            DateTime.Now.Day, 
                                                            DateTime.Now.Second) + ".jpg";
                            foreach (var h in content.Headers.ContentDisposition.Parameters)
                            {
                                if (h.Name.ToLower() == "filename")
                                {
                                    filename = h.Value.Replace("\\", "/").Replace("\"", "");
                                    var pos = filename.LastIndexOf("/");
                                    if (pos >= 0)
                                    {
                                        filename = filename.Substring(pos + 1);
                                    }
                                    break;
                                }
                            }
    
                            string filePath = ConfigurationManager.AppSettings["Pictures"]
                                                                  .ToString();
                            string fullPath = Path.Combine(filePath, filename);
    
                            EncoderParameters encparams = new EncoderParameters(1);
                            encparams.Param[0] = new EncoderParameter(Encoder.Quality, 80L);
                            ImageCodecInfo ici = null;
                            foreach (ImageCodecInfo codec in ImageCodecInfo
                                                             .GetImageEncoders())
                            {
                                if (codec.MimeType == "image/jpeg")
                                {
                                    ici = codec;
                                    break;
                                }
                            }
    
                            image.JpegOrientation().Save(fullPath, ici, encparams);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                result.StatusCode = HttpStatusCode.InternalServerError;
            }
    
            return result;
        }
        else
        {
            throw new HttpResponseException(Request.CreateResponse(
                                            HttpStatusCode.NotAcceptable, 
                                            "This request is not properly formatted"));
        }
    }
