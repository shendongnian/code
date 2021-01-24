    public class PeopleController : ODataController
    {
        [EnableQuery]
        public IQueryable<People> Get()
        {
            return db.people.AsQueryable();
        }
    }
