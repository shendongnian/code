    public class MyContext : DbContext
    {
       public DbSet<ModelImage> ModelImages { get; set; }
       public DbSet<ModelTag> ModelTags { get; set; }         
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       {
           optionsBuilder.UseSqlite("Filename=ModelImageDatabase.db");
       } 
       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           modelBuilder.Entity<ModelImageTag>()
               .HasKey(x => new { x.ModelImageId, x.ModelTagId });
           modelBuilder.Entity<ModelImageTag>()
               .HasOne(x => x.ModelImage)
               .WithMany(x => x.Tags)
               .HasForeignKey(x => x.ModelImageId);
           modelBuilder.Entity<ModelImageTag>()
               .HasOne(x => x.ModelTag)
               .WithMany(x => x.Images)
               .HasForeignKey(x => x.ModelTagId);
       }
    }
