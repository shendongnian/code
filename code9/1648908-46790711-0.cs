    public class GroupController : ApiController
    {
        protected IRepository Repository;
        protected ISettings Settings;
    
        public GroupController(ISettings settings, IRepository repository)
        {
    Settings = settings;
            Repository = repository;
            
        }
    }
