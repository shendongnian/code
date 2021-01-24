    [TypeFilter(typeof(CustomAuthenticationAttribute))
    public class SomeDataController : Controller
    {
        [HttpGet]
        public async Task GetData()
        {
            ...
        }
    } 
