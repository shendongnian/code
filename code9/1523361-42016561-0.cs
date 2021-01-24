    public class RegisterViewModel{
        private ApplicationDbContext db;
        
        public RegisterViewModel()
        {
            db = new ApplicationDbContext();
        }
        public int QueryMaxDepartmentLevel => db.Settings.Find(1).MaxDepartmentLevel;
    }
