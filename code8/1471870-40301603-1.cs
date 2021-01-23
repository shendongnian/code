        public interface ISettings
        {
            void SetSettings(); 
        }
        public interface IDataBaseSettings : ISettings
        {
             string ConnectionString { get; set; }
        }
        public abstract class DatabaseSettings : IDataBaseSettings
        {
            public void SetSettings()
            {
                //todo
            }
            public abstract string ConnectionString { get; set; }
        }
        public class SqlDataBaseSettings : DatabaseSettings
        {
            public override string ConnectionString { get; set; }
        }
     static void Main(string[] args)
      {
            IDataBaseSettings settings  = new SqlDataBaseSettings();
            settings.SetSettings();
            settings.ConnectionString = "Connection String";    
      }
