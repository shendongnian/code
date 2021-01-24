        async Task<bool> DownloadDocument(string authorizationToken, string fileName)
        {
            try
            {
                string url = "yoururl":
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorizationToken);
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    await ReadAsFileAsync(response.Content, fileName, true);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                return false;
            }
