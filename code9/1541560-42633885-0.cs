    public static  string UploadEnvelope(string  filePath,string token, string url )
            {
                            
                
                using (var client = new HttpClient())
                {
                    using (var content =
                        new MultipartFormDataContent("Envelope" + DateTime.Now.ToString(CultureInfo.InvariantCulture)))
                    {
                        content.Add(new StreamContent(new MemoryStream(File.ReadAllBytes(filePath))), "filename", "filename.ext");
    
                        using (
                           var message =
                               await client.PostAsync(url + "/api/Envelope/UploadEnvelope", content))
                        {
                            var input = await message.Content.ReadAsStringAsync();
    
                            return "success";
                        }
                    }
                }
    
            }
