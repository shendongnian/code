     public async void DownloadDataAsync()
        {
            try
            {
                string url = "http://myWebSite.com/jWebService.asmx/GetOffersJSON?storeID=2";
                var httpClient = new HttpClient();
                var content = await httpClient.GetStringAsync(url);
                // de-serializing json response into list, with filtering before
                var startPosition = content.IndexOf('>') + 1;
                var endPosition = content.LastIndexOf("</", StringComparison.Ordinal);
                var filteredResponseCharArray = new char[endPosition - startPosition];
                content.CopyTo(startPosition, filteredResponseCharArray, 0, endPosition - startPosition);
                var listOfOffers = JsonConvert.DeserializeObject<List<offers>>(new string(filteredResponseCharArray));
            }
            catch (Exception error)
            {
                Debug.WriteLine(error);
                throw;
            }
        }
