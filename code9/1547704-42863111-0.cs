      public static class Ext
        {
           public static IQueryable<MainActivity.Student> StudentIsActive(this IQueryable<MainActivity.Student> @this)
            {
                return @this.Where(x => !x.IsDeleted && x.ItemsNumber > 0 && x.Sort > 0 && x.Status == StudentStatus.Active);
            }
    
            public static IQueryable<MainActivity.Student> IsBusy(this IQueryable<MainActivity.Student> @this)
            {
                return @this.Where(x.Mode == ModeType.Busy && x.Jobs.Count() > 0);
            }
    
        }
