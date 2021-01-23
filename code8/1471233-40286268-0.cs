        public static async Task<bool> CallUrl(string url)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept",
                    "text/html,application/xhtml+xml,application/xml");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent",
                    "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch
            {
                return false;
            }
        }
