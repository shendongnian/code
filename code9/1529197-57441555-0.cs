     static async Task uploaddocAsync()
                        {
                            MultipartFormDataContent form = new MultipartFormDataContent();
                            Dictionary<string, string> parameters = new Dictionary<string, string>();
                            //parameters.Add("username", user.Username);
                            //parameters.Add("FullName", FullName);
                            HttpContent DictionaryItems = new FormUrlEncodedContent(parameters);
                            form.Add(DictionaryItems, "model");
                            try
                            {
                                var stream = new FileStream(@"D:\10th.jpeg", FileMode.Open);
                                HttpClient client = new HttpClient();
                                client.BaseAddress = new Uri(@"http:\\xyz.in");
            
                                HttpContent content = new StringContent("");
                                content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                                {
                                    Name = "uploadedFile1",
                                    FileName = "uploadedFile1"
                                };
                                content = new StreamContent(stream);
                                form.Add(content, "uploadedFile1"); 
                                client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.dsfdsfdsfdsfsdfkhjhjkhjk.vD056hXETFMXYxOaLZRwV7Ny1vj-tZySAWq6oybBr2w");
                 
                                var response = client.PostAsync(@"\api\UploadDocuments\", form).Result;
                                var k = response.Content.ReadAsStringAsync().Result;
                            }
                            catch (Exception ex)
                            {
                            }
                        }
