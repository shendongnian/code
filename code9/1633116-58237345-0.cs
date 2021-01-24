csharp
        private static void FindAndConfigureBackgroundJobResultTypes(ModelBuilder modelBuilder)
        {
            var backgroundJobResultTypes = typeof(BackgroundJobResult).Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(BackgroundJobResult))).ToList();
            var sameTypeAndNameProperties = backgroundJobResultTypes
                .SelectMany(x => x.GetProperties())
                .GroupBy(d => new {d.Name, d.PropertyType})
                .Select(grp => new
                {
                    PropertyType = grp.Key.PropertyType,
                    PropertyName = grp.Key.Name,
                    Count = grp.Count()
                })
                .Where(x => x.Count > 1).ToList();
            foreach (var backgroundJobResultType in backgroundJobResultTypes)
            {
                
                //Set base type , instead of exposing this type by DbSet
                modelBuilder.Entity(backgroundJobResultType).HasBaseType(typeof(BackgroundJobResult));
                //Map properties with the same name and type into one column, EF Core by default will create separate column for each type, and make it really strange way. 
                foreach (var propertyInfo in backgroundJobResultType.GetProperties())
                {
                    if (sameTypeAndNameProperties.Any(x => x.PropertyType == propertyInfo.PropertyType && x.PropertyName == propertyInfo.Name))
                    {
                        modelBuilder.Entity(backgroundJobResultType).Property(propertyInfo.PropertyType, propertyInfo.Name).HasColumnName(propertyInfo.Name);
                    }
                }
            }
        }
