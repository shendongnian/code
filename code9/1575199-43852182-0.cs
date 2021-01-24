    public class BaseController : Controller
    {
        //no routing attributes
        public IActionResult CreateImpl(string routeName)
        {
            //place any logic here
            return CreatedAtRoute(routeName, new object());
        }
    }
    [Route("api/[controller]")]
    public class FooController : BaseController
    {
        private const string _getRouteName = "Get_" + nameof(FooController);
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return CreateImpl(_getRouteName);
        }
        [HttpGet(Name = _getRouteName)]
        public override string Get()
        {
            return base.Get();
        }
    }
