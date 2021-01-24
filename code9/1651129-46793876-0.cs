    [HttpGet]
    [Route("company-info/companyinfogetapidata")]
    [AllowAnonymous]
    public HttpResponseMessage CompanyInfoGetApiData(string name, int CompanyCode, string city, string state, int zip)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("URL_BASE");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var request = client.GetAsync("URL_PATH");                
            var json = request.Result.Content.ReadAsStringAsync().Result;
            var res = Request.CreateResponse(HttpStatusCode.OK);
            //Set the content of the response to be JSON Format
            res.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            return res;            
        }
