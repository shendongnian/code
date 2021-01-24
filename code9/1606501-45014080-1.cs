    [Route("api/registration")]
    public class RegistrationController : Controller
    {
        [HttpPost, Route("test/")]
        public ActionResult AddDoc()
        {
            //Get the stream from body
            var stream = Request.Body;
            //Do something with stream
        }
