    public static class Extensions {
        public static IQueryable<User> VisibleInAppOnly(this IQueryable<User> query) 
        {
             return query.Where(x => 
                 x.Settings.IsApproved && x.Settings.IsAvailable && x.UserType == 2);
        }
    }
