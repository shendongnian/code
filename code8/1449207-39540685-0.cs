    public static class ModelBuilderExtensions 
    {
        public static void SetSimpleUnderscoreTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {                        
                Regex underscoreRegex = new Regex(@"((?<=.)[A-Z][a-zA-Z]*)|((?<=[a-zA-Z])\d+)");            
                entity.Relational().TableName = underscoreRegex.Replace(entity.DisplayName(), @"_$1$2").ToLower();
            }
        }
    }
