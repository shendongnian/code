                // Request body
                HttpResponseMessage response;
                string responseBodyAsText;
    
                using (var content = new ByteArrayContent((baseEncodeImage(getPhoto.FileName))))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    response = await client.PostAsync(uri, content);
                    responseBodyAsText = await response.Content.ReadAsStringAsync();
    
                    //debug prints
                    Console.Write(responseBodyAsText + "\n" + getPhoto.FileName + "\n");
    
                }
            }
            
    
            public byte[] baseEncodeImage(string filePath){
                //This function will take the filepath selected from the filedialog
                //and turn it into a base64 encoded stream to be used by the face api
                using (Image image = Image.FromFile(filePath))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        FileStream imgStream = File.OpenRead(filePath);
                        byte[] blob = new byte[imgStream.Length];
                        imgStream.Read(blob, 0, (int)imgStream.Length);
                        return blob;
                    }
                }
    
    
            }
    
