    using System.Web.Http;
    
    [RoutePrefix("api/ticket")]
    public class TicketController : ApiController {
        private readonly ITicketService _TicketService = new TicketService();
    
        //GET api/ticket/Prepare/123456789
        [HttpGet]
        [Route("Prepare/{number}")]
        public TicketViewModel Prepare(string number) {
            //...
        }
        //...
    }
