     try
                            {
                                HttpClient client = new HttpClient();
                                var model = obj as UserModel ;
                                var url = @"http://localhost:57615/api/UsersApi/";
                                var json = JsonConvert.SerializeObject(model);
                                HttpContent content = new StringContent(json);
                                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                                var response = await client.PostAsync(url, content);
                                var message = await response.Content.ReadAsStringAsync();
                                return message;
                            }
                            catch (Exception x)
                            {
                                // message
                            }
