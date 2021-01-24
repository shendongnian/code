    using Newtonsoft.Json.Linq;
    [HttpGet]
    [Route("company-info/companyinfogetapidata")]
    [AllowAnonymous]
    public ActionResult CompanyInfoGetApiData(string name, int CompanyCode, string city, string state, int zip)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("URL_BASE");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var request = client.GetAsync("URL_PATH");                
            var json = request.Result.Content.ReadAsStringAsync().Result;
            json = JToken.Parse(json).ToString();
                 
            return Json(json, JsonRequestBehavior.AllowGet);         
        }
