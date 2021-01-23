    public interface IDataContext {
        DbSet<Search> Searches { get; set; }
    }
    public class IdentityDataContext : IdentityDbContext<ApplicationUser>, IDataContext { ... }
    public class SearchRepository {
        public SearchRepository(IDataContext context) { ... }
    }
