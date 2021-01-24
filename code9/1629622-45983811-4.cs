    public interface IParentService {
        Task AddParentAsync(ApplicationUser user);
    }
    public class ParentService : IParentService {
        ApplicationDbContext db;
        public ParentService(ApplicationDbContext db) {
            this.db = db;
        }
        public async Task AddParentAsync(ApplicationUser user) {
            Parent parentToCreate = new Parent();
            db.Parents.Add(parentToCreate);
            await db.SaveChangesAsync();
            parentToCreate.account = user;
            await db.SaveChangesAsync();
        }
    }
