    public class PeopleController : ODataController
    {
        [EnableQuery]
        public IQueryable<PuppysDog> Get()
        {
            return db.people.AsQueryable();
        }
    }
