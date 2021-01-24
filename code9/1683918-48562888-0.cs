    public async Task<JObject> ExecutePostAsync(Stream myStreem, string url, string token, string parameter1, string parameter2, string parameter3)
        {
            try
            {
                using (var content = new MultipartFormDataContent("----MyBoundary"))
                {
                    using (var memoryStream = myStreem)
                    {
                        using (var stream = new StreamContent(memoryStream))
                        {
                            content.Add(stream, "file", Guid.NewGuid().ToString() + ".jpg");
                            content.Add(new StringContent(parameter1), "parameter1");
                            content.Add(new StringContent(parameter3), "parameter2");
                            content.Add(new StringContent(parameter3), "parameter3");
                            using (HttpClient client = new HttpClient())
                            {
                                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                                var responce = await client.PostAsync(url, content);
                                string contents = await responce.Content.ReadAsStringAsync();
                                return (JObject.Parse(contents));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
