    public class TestController : ApiController
    {
        [HttpPost]
        [Route("ETLLoad/Database/source")]
        public void Post([FromBody]DatabaseSource source) //method one
        {
        }
        [HttpPost]
        [Route("ETLLoad/Folder/source")]
        public void Post([FromBody]FolderSource source) //method two
        {
        }
    }
