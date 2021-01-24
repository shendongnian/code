    [System.Web.Http.HttpPost]
     public IHttpActionResult Post(object data)
      {
           return Ok(new { results = "POST" });
      }
    
     [System.Web.Http.HttpGet]
      public HttpResponseMessage Get()
      {
           var allUrlKeyValues = Request.GetQueryNameValuePairs();
           var parmVal = allUrlKeyValues.FirstOrDefault(x => x.Key == "echo").Value;
           var resp = new HttpResponseMessage(HttpStatusCode.OK);
           resp.Content = new StringContent(parmVal, System.Text.Encoding.UTF8, "text/plain");
           return resp;
      }
