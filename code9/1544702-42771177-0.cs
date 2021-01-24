     if (request.Headers.Contains(HeaderName) && request.Method.Method.Equals("POST"))
                {
                    var formData = await request.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(formData);
                    data.authenticationToken = request.Headers.GetValues(HeaderName).FirstOrDefault();
                    request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                }
