    public class CountyCityConfiguration : IEntityTypeConfiguration<CountyCity>
    {
        public void Map(EntityTypeBuilder<CountyCity> builder)
    	{
            // Table and Schema Name declarations are optional
            //ToTable("CountyCity", "dbo");
            // composite primary key
            builder.HasKey(p => new { p.CountyId, p.CityId });
            builder.HasOne(pt => pt.County)
                   .WithMany(p => p.CountiesCities)
                   .HasForeignKey(pt => pt.CountyId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(pt => pt.City)
                   .WithMany(t => t.CountiesCities)
                   .HasForeignKey(pt => pt.CityId)
                   .OnDelete(DeleteBehavior.Restrict);
            // TODO: handle orphans when last association is deleted
        }
    }
