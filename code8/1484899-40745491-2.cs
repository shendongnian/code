    var personAdminId = My.UserAdmin.Id;
    
    public class My
    {
        private static User _userAdmin;
        public static User UserAdmin
        {
            get
            {
                if (_userAdmin == null)
                {
                    using (var context = new GdDbContext())
                    {
                        var adminEmail = ConfigurationManager.AppSettings["DefaultGdAdminEmail"];
                        _userAdmin = context.Users.FirstOrDefault(x => x.Email == adminEmail);
                    }
                }
    
                return _userAdmin;
            }
        }
    }
