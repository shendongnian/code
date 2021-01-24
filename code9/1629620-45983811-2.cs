    public interface IParentService {
        Task AssignParentAsync(ApplicationUser user);
    }
    public class ParentService : IParentService {
        ApplicationDbContext db;
        public ParentService(ApplicationDbContext db) {
            this.db = db;
        }
        public async Task AssignParentAsync(ApplicationUser user) {
            Parent parentToCreate = new Parent();
            db.Parents.Add(parentToCreate);
            await db.SaveChangesAsync();
            parentToCreate.account = user;
            await db.SaveChangesAsync();
        }
    }
