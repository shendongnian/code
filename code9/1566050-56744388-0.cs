    public static class ModelBuilderExtensions
    {
        public static ModelBuilder RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.ClrType == null)
                    continue;
                entityType.Relational().TableName = entityType.ClrType.Name;
            }
            return modelBuilder;
        }
    }
