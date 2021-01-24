    public class FooController : ApiController {
        public Lazy<IMyFooService> fooService;
        public FooController(Lazy<IMyFooService> fooService) {
            this.fooService = fooService;
        }
        public JsonResult Get() {}
        public async Task<JsonResult> Post([FromBody] IList foos) {
            var didMyFoo = this.fooService.Value.DoTheFoo();
        }
    }
