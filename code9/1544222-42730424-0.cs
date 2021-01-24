    public class repositories: IDisposable
    {
        private DataClasses1DataContext _db;
        public DataClasses1DataContext db
        {
            get
            {
                if (_db == null)
                {
                    _db = new DataClasses1DataContext();
                }
    
                return _db;
            }
        }
    
        public static void add(registration reg)
        {
            db.sp_insert(reg.Username, reg.password, reg.securityQuestion, reg.SecurityAnswer, reg.LastName, reg.firstName, reg.MiddleInitial, reg.address, reg.gender, reg.birthdate, reg.age);
        }
        public static void Update(registration reg)
        {
            db.sp_Update(reg.Username, reg.password, reg.securityQuestion, reg.SecurityAnswer, reg.LastName, reg.firstName, reg.MiddleInitial, reg.address, reg.gender, reg.birthdate, reg.age);
        }
        public static void delete(registration reg)
        {
            db.sp_Delete(reg.UserId);
        }
        public static List<sp_ViewResult> View()
        {
            List<sp_ViewResult> View() = db.sp_view().Tolist<sp_viewResult>();
        }
    
        public void Dispose()
        {
            db.Dispose();
        }
    }
