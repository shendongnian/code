            public async Task<object> UploadImage()
                {
                    var fileBytes = new List<byte[]>();
                    var files = 
                       _httpContextAccessor.HttpContext.Request.Form.Files;
    
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);
                            fileBytes.Add(memoryStream.ToArray());
                        }
                    }
                }
       // TODO: Write Code For Save Or Send Result To Another Services For Save
                }
