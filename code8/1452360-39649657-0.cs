    // Type parameter renamed to follow normal .NET naming conventions
    public abstract class BaseService<T> where T : class
    {
        private readonly BaseRepository<T> repo;
    
        protected BaseService(BaseRepository<T> repo)
        {
            this.repo = repo;
        }
        public T Get(object id)
        {
            // Do generic get entities
            return repo.Get(id);
        }
    }
    public class UserService : BaseService<User>
    {
        public UserService() : base(new UserRepository())
        {
        }
    }
