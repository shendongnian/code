    public class ValuesController : ApiController
    {
        // GET http://localhost/api/values?$expand=Supplier&$filter=fullname eq 'Ken Arok'
        public IHttpActionResult Get()
        {
            var dics = Request.GetQueryNameValuePairs().ToDictionary(q=>q.Key,q=>q.Value);
            string filter = null;
            dics.TryGetValue("$filter", out filter);
            
            //TODO:
            return Content(HttpStatusCode.OK,filter);
            //return Json(Request.GetQueryNameValuePairs().Select(q => new { key = q.Key, value = q.Value }));
        }
    }
