    public class MyService : IMyService
    {
        private readonly MyDbContext _context;
    
        public MyService(MyDbContext ctx){
             _context = ctx;
        }
    
        public User GetUser(string username)
        {
            var users = from u in _context.User where u.WindowsLogin == username select u;
            if (users.Count() == 1)
            {
                return users.First();
            }
            return null;
        }
    }
    public interface IMyService
    {
        User GetUser(string username);
    }
