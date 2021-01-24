    using (var client = new HttpClient())
    {
         client.BaseAddress = new Uri(Baseurl);
         client.DefaultRequestHeaders.Clear();
         client.DefaultRequestHeaders.Accept.Add(new 
         MediaTypeWithQualityHeaderValue("application/json"));
         HttpResponseMessage response = await client.PostAsJsonAsync("api/RPDeployment/BIL_CFP_BOX_CHECK_STATUSPTC", checkStatusParam);
         if(response.IsSuccessStatusCode)
           {
                var EmpResponse = response.Content.ReadAsStringAsync().Result;
                ListStatusPTC = JsonConvert.DeserializeObject<CheckStatus>(EmpResponse); // the JSON contains an object, so this needs to deserialize to an object. you can't deserialize to a list.
    
           }
     }
