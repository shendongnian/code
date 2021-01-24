    public interface IConfiguration
    {
        List<object> GetConfiguration(string configuration);
    }
    public class Configurations : IConfiguration
    {
        private readonly List<object> Container = new List<object>();
        public List<object> GetConfiguration(string configuration)
        {
            -- return the needed subelement --
            return Container(configuration);
        }
    }
