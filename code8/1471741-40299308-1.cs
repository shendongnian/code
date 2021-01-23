        public interface IRepository
        {
            //repository contracts
        }
    
        public interface IRepositoryFactory
        {
            IRepository Create(string arguments);
        }
    
        public interface IRepositoryBuilder
        {
            RepositoryType Type { get; }
            IRepository Create(string args);
        }
    
        public class ApplicationSettings
        {
            public RepositoryType RepositoryType { get; set; }
        }
    
        public enum RepositoryType { Json, Text }
    
        // Default implementation of repository factory based on applicationsettings.
        public class ConfigurableRepositoryBuilder:IRepositoryFactory
        {
            private readonly ApplicationSettings _settings;
            private readonly IEnumerable<IRepositoryBuilder> _repositoryBuilders;
    
            public ConfigurableRepositoryBuilder(ApplicationSettings settings, IEnumerable<IRepositoryBuilder> repositoryBuilders)
            {
                _settings = settings;
                _repositoryBuilders = repositoryBuilders;
            }
    
            public IRepository Create(string arguments)
            {
                var builder = _repositoryBuilders.First(x => x.Type == _settings.RepositoryType);
                //configure builder settings and then call create
                return builder.Create(arguments);
            }
        }
