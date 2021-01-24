        private static void SplitIntoTables<T>(DbModelBuilder modelBuilder, IReadOnlyCollection<PropertyInfo> properties, int columnLimit) where T : class
        {
            var numberOfTables = Math.Ceiling((properties.Count + (double)columnLimit / 2) / columnLimit);
            var paramExp = Expression.Parameter(typeof(T));
            var tableIndex = 0;
            foreach (var tableGroup in properties.GroupBy(p => p.Name.GetHashCode() % numberOfTables))
            {
                var expressions = tableGroup.Select(p => Expression.Lambda(
                    typeof(Func<,>).MakeGenericType(typeof(T), p.PropertyType),
                    Expression.Property(paramExp, p), paramExp));
                modelBuilder.Entity<T>().Map(m =>
                {
                    foreach (var exp in expressions)
                    {
                        m.Property((dynamic) exp);
                    }
                    m.ToTable($"{typeof(T).Name}_{++tableIndex}");
                });
            }
        }
