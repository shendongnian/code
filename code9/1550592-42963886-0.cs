    public class apiController : Controller
    {
        [Route("api/fleet/{id:guid}/selectedfleet")]
        public ActionResult selectedfleet(Guid id)
        {
            return Content(id.ToString());
        }
    }
