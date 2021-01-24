    public async Task<List<IHttpActionResult>> Get()
    {
        ......
     
        var responses = new List<IHttpActionResult>>();
        var response = await iLab_client.GetAsync(uri_serviceid);
        var datafile = await response.Content.ReadAsStringAsync();
        var returnDataObj = JsonConvert.DeserializeObject<Models.ReqDTO.RootObject>(datafile);
        foreach (var req in returnDataObj.il_response.svc_req)
        {
            int request_id = req.id;
            //Calling the other service passing the input parameter
            using (var iLab_client_request = new HttpClient())
            {
                string request_Uri = BaseURL_iLab + "svc_req/"+request_id+"/c_forms.json";
                Uri uri_request = new Uri(request_Uri);
                client_request.BaseAddress = uri_request;
                client_request.DefaultRequestHeaders.Accept.Clear();
                client_request.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client_request.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                var request_response = await client_request.GetAsync(uri_request);
                var responsefile = await request_response.Content.ReadAsStringAsync();
                var request_returnDataObj = JsonConvert.DeserializeObject<Models.DTO.RootObject>(responsefile);
                responses.Add(request_returnDataObj);
            }
        }
        return responses;
    }
