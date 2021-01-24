I am using below code for calling API may this one help u.Here i am passing one class object u replace this by Dictionary and try..
    public void insertData(OCMDataClass kycinfo, string clientId, string type)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["CBService"]);
                    string postBody = Newtonsoft.Json.JsonConvert.SerializeObject(kycinfo);
                    var jsonString = JsonConvert.SerializeObject(kycinfo);
                    var content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
                    var myContent = JsonConvert.SerializeObject(kycinfo);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);
                    var result = client.PostAsync("Bfilvid/api/SvcVId/CreateKYCRepository", content).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        string resultContent = result.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        string resultContent = result.Content.ReadAsStringAsync().Result;
                    }
                }
            }
            catch (Exception ex)
            {
            }
