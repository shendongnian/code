    // other solution
    [Route("aim/v1/contacts/[Action]")]
    public class aimContactsController : Controller
    {
        [HttpPost("{id}")]
        public IActionResult delete(string id)
        {
            // omitted ...
        }
    }
