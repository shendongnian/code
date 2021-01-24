    public class MyDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>().HasMany(it => it.Architects).WithMany(it => it.BuildingsBeingWorkedOn);
            modelBuilder.Entity<Building>().HasMany(it => it.BuildingGroups).WithMany(it => it.Buildings);
            base.OnModelCreating(modelBuilder);
        }
    }
