            [HttpPost]
            [Route("GetContactFileLink")]
            public HttpResponseMessage GetContactFileLink([FromBody]JObject obj)
            {
                    string exportURL = "d:\\xxxx.text";//replace with your filepath
    
                    var fileName =  obj["filename"].ToObject<string>();
    
                    exportURL = exportURL+fileName;
    
                    var resullt = CreateZipFile(exportURL);
    
                    
                    return resullt;
            }
    private HttpResponseMessage CreateZipFile(string directoryPath)
            {
                try
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
    
                    using (ZipFile zip = new ZipFile())
                    {
                        zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                        zip.AddFile(directoryPath, "");
                        //Set the Name of Zip File.
                        string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            //Save the Zip File to MemoryStream.
                            zip.Save(memoryStream);
    
                            //Set the Response Content.
                            response.Content = new ByteArrayContent(memoryStream.ToArray());
    
                            //Set the Response Content Length.
                            response.Content.Headers.ContentLength = memoryStream.ToArray().LongLength;
    
                            //Set the Content Disposition Header Value and FileName.
                            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                            response.Content.Headers.ContentDisposition.FileName = zipName;
    
                            //Set the File Content Type.
                            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/zip");
                            return response;
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw new ApplicationException("Invald file path or file not exsist");
                }
            }
