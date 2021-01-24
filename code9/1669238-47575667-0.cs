    [MyAuthorize(Roles = "addedit, admin", Except = "Get")]
    public class JobsController : BaseODataController<Job>
    {
        [MyAuthorize(Roles = "addedit, admin, newrole")]
        public Job Get(int Id)
        {
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
