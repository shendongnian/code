    [Authorize("addedit, admin")]
    public class JobsController : BaseODataController<Job>
    {
        [AllowAnonymous]
        public Job Get(int Id)
        {
            //Check the roles (addedit, admin, newrole) manually
            //stuff
        }
    
        public IHttpActionResult Post(Job job)
        {
            //stuff
        }
    
        public IHttpActionResult Update(int id)
        {
            //stuff
        }
    }
