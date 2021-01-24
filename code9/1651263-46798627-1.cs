    [HttpGet]
    [Route("company-info/companyinfogetapidata")]
    [AllowAnonymous]
    public PartialViewResult CompanyInfoGetApiData(string name, int CompanyCode, string city, string state, int zip)
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("URL_BASE");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var request = client.GetAsync("URL_PATH");                
        var json = request.Result.Content.ReadAsStringAsync().Result;
        JObject o = JObject.Parse(json);
        return PartialView(@"_CompanyFinderResults.cshtml", Model);
    }
