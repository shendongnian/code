    public interface IConfigurationProvider
    {
        RepositoryType SelectedRepositoryType { get; set; }
    }
    public class ConfigurationProvider : IConfigurationProvider
    {
        public RepositoryType SelectedRepositoryType
        {
            get { /* read the value from some configuration file */ }
            set { /* store the new value */ }
        }
    }
