    using Microsoft.EntityFrameworkCore;
    
    namespace DL.SO.MessageEnum.Web.UI.Models
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
    
            public DbSet<MessageMeta> Messages { get; set; }
            public DbSet<EnumMeta> Enums { get; set; }
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<MessageMeta>()
                    .HasKey(x => x.MsgId);
    
                modelBuilder.Entity<EnumMeta>()
                    .HasKey(x => x.EnumId);
    
                modelBuilder.Entity<MessageEnum>()
                    .HasKey(x => new { x.MessageMetaId, x.EnumMetaId });
                modelBuilder.Entity<MessageEnum>()
                    .HasOne(x => x.MessageMeta)
                    .WithMany(m => m.EnumMetas)
                    .HasForeignKey(x => x.MessageMetaId);
                modelBuilder.Entity<MessageEnum>()
                    .HasOne(x => x.EnumMeta)
                    .WithMany(e => e.MessageMetas)
                    .HasForeignKey(x => x.EnumMetaId);
            }
        }
    }
