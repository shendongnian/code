    public class ValuesAsParamController : ApiController
    {
        [HttpGet]
        public IEnumerable<string> Call(string myparam)
        {
            // Do something with your 'myparam' value
        }
    }
