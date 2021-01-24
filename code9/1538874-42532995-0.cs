    public static class IdentityExtensions
    {
        public static string GetEmailAdress(this IIdentity identity)
        {
            var userId = identity.GetUserId();
            using (var context = new DbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                return user.Email;
            }
        }        
    }
