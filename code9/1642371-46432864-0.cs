    public class ApplicationDbContext : DbContext
    {
        ...
        public bool HasDota2Account(string id)
        {
            return Dota2Accounts.Any(m => m.ApplicationUserId == id);
        }
    }
