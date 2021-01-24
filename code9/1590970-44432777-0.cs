    using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Add("User-Agent", "CBS Brightcove API Service");
                string authorization = GenerateBase64();
                client.DefaultRequestHeaders.Add("Authorization", authorization);
                using (var content = new MultipartFormDataContent())
                {
                    string fileName = Path.GetFileName(textBox1.Text);
                    //Content-Disposition: form-data; name="json"
                    var stringContent = new StringContent(InstancePropertyObject);
                    stringContent.Headers.Remove("Content-Type");
                    stringContent.Headers.Add("Content-Type", "application/json");
                    stringContent.Headers.Add("Content-Disposition", "form-data; name=\"instance\"");
                    content.Add(stringContent, "instance");
                    var fileContent = new ByteArrayContent(filecontent);
                    fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = fileName
                    };
                    content.Add(fileContent);
                    var result = client.PostAsync(targetURL, content).Result; 
                }
            }
