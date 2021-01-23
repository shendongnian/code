    public class Test {
        public IList<Question> Questions { get; set; }
    }
    public class TestController : ApiController {
        [HttpPost]
        public IHttpActionResult Create(Test test) { ... }
    }
