    public class DefaultDbContextFactory : IDbContextFactory<DefaultDbContext>{
    public DefaultDbContext Create()
    {
        return new DefaultDbContext("Server=XXXX ;Database=XXXXX;Trusted_Connection=True;");
    }
