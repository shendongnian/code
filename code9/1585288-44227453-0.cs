    public async Task<List<ModelPageLocationList>> RefreshPageLocationListAsync ()
        {
            DataPageLocationList = new List<ModelPageLocationList>();
            var uri = new Uri(string.Format(WebServiceSettings.WebServiceUrl, string.Empty));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("BEFORE {0}", content.ToString());
                    
                    content = content.Substring(content.IndexOf('['), content.IndexOf(']') - content.IndexOf('[') + 1);
                    Debug.WriteLine("AFTER {0}", content.ToString());
                    DataPageLocationList = JsonConvert.DeserializeObject<List<ModelPageLocationList>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
            return (DataPageLocationList);
        }
