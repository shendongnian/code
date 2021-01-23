    public class SecurityHelpers
    {
        public static IList<ApplicationUser> GetAllStaff()
        {            
            using(var db = new Context())
            {
                var users = db.Users
                        .OrderBy(x => x.FirstName).ThenBy(x => x.LastName)
                        .ToList();            
                return users;
            }
        }
    }
