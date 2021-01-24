    public class BaseEntityApiController<Repository, BaseEntity> : ApiController
        where Repository : BaseRepository<BaseEntity>, new()
    {
        Repository repository = new Repository();
    
        public IList<BaseEntity> Get()
        {
             return repository.FindAll();
        }
    
    }
