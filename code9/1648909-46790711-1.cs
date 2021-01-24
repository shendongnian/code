    public class GroupController : ApiController
    {
        protected IRepository Repository;
        protected ISettings Settings;
    
        public GroupController(ISettings settings, IRepository repository)
        {
            Settings = settings;
            Repository = repository;
            Repository.RepoConfig = User.Identity.IsAuthenticated ? Settings.ConfigAuth : Settings.Config
        }
    }
    public class Repository : IRepository
    {
       private readonly RepoConfig _config;
    
       public RepoConfig RepoConfig
       {
           get => _config;
           set
           {
               _config = value;
           }
       }
       ...
    }
