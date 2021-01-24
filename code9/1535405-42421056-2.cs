    [EnableQuery]
    public class PeopleController : ODataController
    {
        public IHttpActionResult Get()
        {
            return Ok(SomeDataSource.Instance.People.AsQueryable());
        }
    }
