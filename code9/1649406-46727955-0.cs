    public interface IRepositoryConnectionString
    {
        void SetConnectionString(string connectionString);
    }
    
    public interface IPersonRepository : IRepositoryConnectionString ...
    public class FilePersonRepository : IPersonRepository
    {
        /* file related private fields here */
        public FilePersonRepository ()
        {
            SetConnectionString(ConfigurationManager.ConnectionStrings[
                "FilePersonRepository.ConnectionString"]);
        }
        public SetConnectionString(string connectionString)
        {
             /* do all required stuf like flush previous file, open file, etc...  */ 
        }
    
        /* Interface members here... */
    }
