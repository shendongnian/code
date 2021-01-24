    [Route("api/[controller]/[action]")] //<--include action
    public class CustomerController : Controller
    {
    ...
        [HttpGet,ActionName("Get")] //<--I don't know if it's necesary
        public List<Customer> Get() {..}
        [HttpPost, ActionName("PostCust")] //<--give there the "actionName
        [AllowAnonymous]
        public JsonResult PostCust([FromBody]int[] customerIDs){...}
    
    }
