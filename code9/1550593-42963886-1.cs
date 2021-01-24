    [RoutePrefix("api")]
    public class apiController : Controller
    {
        [Route("fleet/{id:guid}/selectedfleet")]
        public ActionResult selectedfleet(Guid id)
        {
            return Content(id.ToString());
        }
    }
