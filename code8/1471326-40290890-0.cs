    public class GamesController : ApiController
        {
            // GET api/<controller>
            [HttpPost]
            public async Task<IHttpActionResult> Post(RequestDocument[] document)
            {
                var req = await Request.Content.ReadAsStringAsync();
                return Ok();
            }
        }
    
    public class RequestDocument
        {
            [Required]
            public int RequestID { get; set; }
            [Required]
            public int DocumentID { get; set; }
            [Required]
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }
