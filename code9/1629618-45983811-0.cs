    public interface IParentService {
        void AssignParent(ApplicationUser user);
    }
    public class ParentService : IParentService {
        ApplicationDbContext db;
        public ParentService(ApplicationDbContext db) {
            this.db = db;
        }
        public void AssignParent(ApplicationUser user) {
            Parent parentToCreate = new Parent();
            db.Parents.Add(parentToCreate);
            db.SaveChanges();
            parentToCreate.account = user;
            db.SaveChanges();
        }
    }
