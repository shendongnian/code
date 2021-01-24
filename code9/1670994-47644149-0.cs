    public interface IDatabaseService {
        List<ApplicationUser> GetUsers();
        //...
    }
    
    public class DatabaseService : IDatabaseService {
    
        public DatabaseService(ApplicationDbContext context) {
            //...code removed for brevity
        }
    
        //...code removed for brevity
    }
