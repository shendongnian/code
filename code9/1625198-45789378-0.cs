    public class AppointmentController : ApiController {
        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post([FromBody]Appointment app) {
            app.Save();
            return Ok();
        }
    }
