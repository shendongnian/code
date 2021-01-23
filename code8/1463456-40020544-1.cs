    private async void GetData(object sender, EventArgs e)
    {
        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri("ipaddress");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                HttpResponseMessage response = client.GetAsync("WebServices/information.svc/GetInformationJSON").Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    dynamic dynamicObject = JsonConvert.DeserializeObject(jsonString);
                }
            }
            catch
            {
            }
        }
    }
