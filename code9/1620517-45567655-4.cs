     public class BbContext :IdentityDbContext<IdentityUser>
        {
            public BbContext(DbContextOptions options):base(options)
            {
                Database.EnsureCreated();
            }
    
            public DbSet<Artist> Artists { get; set; }
            public DbSet<Lyric> Lyrics { get; set; }
            public DbSet<Heart> Hearts { get; set; }
    
            protected override void OnModelCreating(ModelBuilder builder)
            {
                builder.Entity<BbUser>(b => b.ToTable("AspNetUsers"));
                builder.Entity<Heart>().HasKey(h => new {h.UserId, h.LyricId});
                base.OnModelCreating(builder);
            }
        }
