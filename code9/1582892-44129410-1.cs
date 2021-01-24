                        string url = "domain/api/controller/method?parameter1=param";
                        using (var client = new HttpClient())
                        {
                            HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
                            if (response.IsSuccessStatusCode)
                            {
                                var jsonResponse = response.Content.ReadAsStringAsync().Result;
                                bool data = JsonConvert.DeserializeObject<bool>(jsonResponse);
                                return data;
                            }
                        }
