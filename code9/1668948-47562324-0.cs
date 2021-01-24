    public partial class MYDBContext : DbContext
    {
        public MYDBContext(DbContextOptions<MYDBContext> options)
            : base(options)
        {
        }
