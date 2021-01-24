    public class ValuesController : ApiController
    {
      [HttpGet]
      public IHttpActionResult Get()
      {
        string url = Url.Link("GetStatusFeedback", new { Id = 1, Action = "Accept", Controller = "values"});
        /*or*/ url = Url.Link(nameof(Accept), new { Id = 1,      Action = "Accept", Controller = "values"});
        //not  url = Url.Link(nameof(Accept), new { LeadId = 1,  Action = "Accept", Controller = "values"});
        return Ok(url);
      }
    // Controller we want to get the URL of:
    [HttpPost("leads/{id:int}/statusfeedback", Name = "GetStatusFeedback")]
    public void Accept(int id) //param name matches the line above {id} (in OP it mismatched)
    {
    }
