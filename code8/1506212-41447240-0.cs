    public class MyContext : DbContext 
    {
        DbSet<Notifikation> Notifications { get; set; }
        DbSet<PageNotifikation> PageNotifications { get; set; }
    }
    MyContext.PageNotifications.SqlQuery(...)
