    public class MyDbContext : DbContext
    {
        public DbQuery<MyModelView> MyView
        {
            get
            {
                // Don't track changes to query results
                return Set<MyModelView>().AsNoTracking();
            }
        }
    }
