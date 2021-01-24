    public class ChartsController : ApiController {
        private readonly IUserDataAccessor accessor;
        public ChartsController(IUserDataAccessor accessor) {
            this.accessor = accessor;
        }
        [HttpGet]
        public IHttpActionResult SomeAction() {
            var userData = accessor.UserData;
            //...do something associated with user data
            return OK();
        }
    }
