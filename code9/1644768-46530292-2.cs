    [RoutePrefix("Events")]
    public class EventsController : Controller
    {
        ...
        [Route("LocationEvents", Name = "LocationEvents")]
        public ActionResult LocationEvents(int locationId)
        {
            ...
        }
    }
