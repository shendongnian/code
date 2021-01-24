    [Route("api/Hello")]
    public class HelloController : Controller {
        StudentContext db = new StudentContext();
        [HttpGet] // Matches GET api/Hello
        [HttpGet("Ghouse")] // Matches GET api/Hello/Ghouse
        public string Ghouse() {
            var x = from n in db.StudentMaster
                    select n;
            return "Hello Ghouse";
        }
    }
