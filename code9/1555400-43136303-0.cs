    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDbModelCacheKeyProvider, IDisposable {
        public ApplicationDbContext(string schemaname, string connString)
            : base(connString) {                
            SchemaName = schemaname;
            ((IObjectContextAdapter) this).ObjectContext.CommandTimeout = 180;
        }
        public static ApplicationDbContext Create(string schemaName) {
            return new ApplicationDbContext(schemaName, HttpContext.Current.Session["ConnString"].ToString());
        }
    }
