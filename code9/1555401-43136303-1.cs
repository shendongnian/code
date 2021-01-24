    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDbModelCacheKeyProvider, IDisposable {
        public ApplicationDbContext(string schemaname, string connString)
            : base(connString) {                
            SchemaName = schemaname;
            ((IObjectContextAdapter) this).ObjectContext.CommandTimeout = 180;
        }
        public ApplicationDbContext(string schemaname)
           : this(schemaname, HttpContext.Current.Session["ConnString"].ToString())
        {            
        }
    }
