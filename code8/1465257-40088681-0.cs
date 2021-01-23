        [TestMethod]
        public async Task TestUrls()
        {
            Assert.IsTrue(await UrlIsReachable("http://stackoverflow.com"));
            Assert.IsFalse(await UrlIsReachable("http://111.222.333.444"));
        }
        private async Task<bool> UrlIsReachable(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }            
            catch 
            {
                return false;
            }
        }
