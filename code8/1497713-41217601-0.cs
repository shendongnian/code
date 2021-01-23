    //Convert each of the three inputs into HttpContent objects
                    byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                    
                    HttpContent bytesContent = new ByteArrayContent(fileBytes);
    
                    // Submit the form using HttpClient and 
                    // create form data as Multipart (enctype="multipart/form-data")
    
                    using (var client = new System.Net.Http.HttpClient())
                    using (var formData = new MultipartFormDataContent())
                    {
                        // <input type="text" name="filename" />
                        formData.Add(bytesContent, "filename", Path.GetFileName(filePath));
    
                        // Actually invoke the request to the server
    
                        // equivalent to (action="{url}" method="post")
                        var response = client.PostAsync(url, formData).Result;
    
                        // equivalent of pressing the submit button on the form
                        if (!response.IsSuccessStatusCode)
                        {
                            return null;
                        }
                        return response.Content.ReadAsStreamAsync().Result;
                    }
