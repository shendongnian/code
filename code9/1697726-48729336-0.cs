    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    public class ValuesController : ApiController
    {
            [HttpPost]
            [Route("api/CreateRecord")]
            public async Task<HttpResponseMessage> CreateRecord([FromBody] List<DomesticDepartureEntry> dentries)
            {
                try
                {
                   if (ModelState.IsValid)
                   {
                      db.DomesticDepartureEntries.AddRange(dentries);
                      db.SaveChanges();
                      return new HttpResponseMessage()
                    {
                        Content = new ObjectContent<JObject>(new JObject { new JProperty("message", "Record successfully inserted into the database!") }, new JsonMediaTypeFormatter()),
                        StatusCode = HttpStatusCode.OK
                    };
    
                   }
                }
                catch(Exception ex)
                {
                   return new HttpResponseMessage()
                    {
                        Content = new ObjectContent<JObject>(new JObject { new JProperty("message", $"Failed because: {ex.Message}") }, new JsonMediaTypeFormatter()),
                        StatusCode = HttpStatusCode.ExpectationFailed
                    };
                }
            }
    }
