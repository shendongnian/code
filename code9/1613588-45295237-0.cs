    // other code omitted for clarity
    [Route("aim/v1/contacts/")]
    public class aimContactsController : Controller
    {
        [HttpPost("delete/{id}")]
        public IActionResult delete(string id)
        {
            // omitted ...
        }
    }
