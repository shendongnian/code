    public interface IDbRepository 
    {
       // Add methods signature here
       public List<Post> GetPosts();
    }
    public class DBRepository : IDbRepository 
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public DBRepository(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        //implement those methods
        public List<Post> GetPosts()
        {
            // to do  : return a list of Posts
        }
    }
