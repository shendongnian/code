       public async Task<HttpResponseMessage> GetOrder(string url)
        {
            string xml = "<result><success> True </success><message></result>";
            return await Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage()
                                                        {
                                                            Content = new StringContent(xml, Encoding.UTF8, "application/xml")
                                                        });
        }
