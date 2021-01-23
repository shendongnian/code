    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
    namespace Microsoft.EntityFrameworkCore
    {
        public abstract class EntityTypeConfiguration<TEntity>
            where TEntity : class
        {
            public abstract void Map(EntityTypeBuilder<TEntity> builder);
        }
    
        public static class ModelBuilderExtensions
        {
            public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, EntityTypeConfiguration<TEntity> configuration)
                where TEntity : class
            {
                configuration.Map(modelBuilder.Entity<TEntity>());
            }
        }
    }
