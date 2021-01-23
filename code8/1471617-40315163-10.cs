    namespace Dna.NetCore.Core.DAL.EFCore.Configuration.Temporary.Cocowalla
    {
        // attribute: http://stackoverflow.com/questions/26957519/ef-7-mapping-entitytypeconfiguration/35373237#35373237
        public interface IEntityTypeConfiguration<TEntityType> where TEntityType : class
        {
            void Map(EntityTypeBuilder<TEntityType> builder);
        }
    }
