      /// <summary>
        /// Actual Repository
        /// </summary>
        public interface IRepository
        {
            //repository contracts
        }
    
        /// <summary>
        /// Factory Abstraction
        /// </summary>
        public interface IRepositoryFactory
        {
            IRepository Create(string arguments);
        }
    
        /// <summary>
        /// Specific repository builder
        /// </summary>
        public interface IRepositoryBuilder
        {
            RepositoryType Type { get; }
            IRepository Create(string args);
        }
    
        /// <summary>
        /// global settings, register as singleton
        /// </summary>
        public class ApplicationSettings
        {
            public RepositoryType RepositoryType { get; set; }
        }
    
        /// <summary>
        /// Supported types of repository types
        /// </summary>
        public enum RepositoryType
        {
            Json,
            Text
        }
    
        /// <summary>
        /// Default implementation of repository factory based on applicationsettings.
        /// </summary>
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
                //configure builder settings and then
                //call create
                return builder.Create(arguments);
            }
        }
