    $.ajax({
      type: 'POST',
      url: '/Business/Expenses', // http route
      // [...]
    });
----------
    [RoutePrefix("Business")]
    public class ExpensesController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Save([FromBody] string questions)
        {
            // do stuff
            return Ok("something");
        }
    }
