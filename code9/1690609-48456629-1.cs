    public class FilterModel
    {
        [JsonProperty("$filter")]
        public string Filter { get; set; }
        [JsonProperty("$expand")]
        public string Expand { get; set; }
        //add other options for OData
    }
    public class ValuesController : ApiController
    {
        // POST api/values
        public IHttpActionResult Post([FromBody]FilterModel filter)
        {   
            //TODO:
            return Json(filter);
        }
    }
