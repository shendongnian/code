    namespace Dna.NetCore.Core.DAL.EFCore.Configuration.Common
    {
        public class StateOrProvinceConfiguration : IEntityTypeConfiguration<StateOrProvince>
        {
            public void Map(EntityTypeBuilder<StateOrProvince> builder)
            {
                // EF Core
                builder.HasOne(p => p.Country).WithMany(p => p.StateOrProvinces).HasForeignKey(s => s.CountryId).OnDelete(DeleteBehavior.Cascade);
                builder.HasMany(d => d.Cities).WithOne().OnDelete(DeleteBehavior.Cascade);
                builder.HasMany(d => d.Counties).WithOne().OnDelete(DeleteBehavior.Cascade);
            }
        }
    }
