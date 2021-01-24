    public async void DownloadDataAsync()
            {
                try
                {
                    string url = "http://myWebSite.com/jWebService.asmx/GetOffersJSON?storeID=2";
                    var httpClient = new HttpClient();
                    Task<string> downloadTask = httpClient.GetStringAsync(url);
                    string content = await downloadTask;
                }
                catch (Exception errorDownloadData)
                {
                    Debug.WriteLine(errorDownloadData);
                    throw;
                }
                try
                {
                    // de-serializing json response into list
                    JObject jsonResponse = JObject.Parse(content);
                    IList<JToken> results = jsonResponse["offs"].ToList();
                    foreach (JToken token in results)
                    {
                        offers poi = JsonConvert.DeserializeObject<offers>(token.ToString());
                        offs.Add(poi);
                    }
                }
                catch (Exception errorDeserializeData)
                {
                    Debug.WriteLine(errorDeserializeData);
                    throw;
                }
            }
