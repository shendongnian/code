        public async Task Put(string id)
        {
            Stream fileContent = Request.Body;
            using (var handler = new HttpClientHandler() { Credentials = new NetworkCredential("XXX", "XXX") })
            {
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(@"http://X.X.X.X/documents");
                    using (var payload = new StreamContent(fileContent))
                    {
                        var response =
                            await client.PutAsync(string.Format("?uri={0}.xml", id), payload);
                        if (response.IsSuccessStatusCode)
                        {
                            Created("urltocontent", null);
                        }
                        else
                        {
                            BadRequest();
                        }
                    }
                }
            }
        }
