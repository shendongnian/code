    public class ColumnOrderConfiguration<TEntity>
    {
        public Func<TEntity, object> ValueSelector { get; set; } = entity => null;
        public SortOrder SortOrder { get; set; } = SortOrder.Ascending;
    }
    public static class CollectionPreparationExtensions
    {
        public static IEnumerable<TEntity> Prepare<TEntity>(this IEnumerable<TEntity> entities, Func<TEntity, bool> predicate, IEnumerable<ColumnOrderConfiguration<TEntity>> orderConfiguration, int pageIndex, int pageSize)
            => entities.Where(predicate).OrderBy(orderConfiguration).Skip(pageIndex * pageSize).Take(pageSize);
        private static IEnumerable<TEntity> OrderBy<TEntity>(this IEnumerable<TEntity> entities, IEnumerable<ColumnOrderConfiguration<TEntity>> orderConfiguration)
        {
            var configurations = orderConfiguration.ToArray();
            if (!configurations.Any())
                return entities;
            
            var firstOrderConfiguration = configurations.First();
            var orderedEntities = entities.OrderBy(firstOrderConfiguration.ValueSelector, firstOrderConfiguration.SortOrder);
            for (var i = 1; i < configurations.Length; i++)
            {
                orderedEntities = orderedEntities.ThenBy(configurations[i].ValueSelector, configurations[i].SortOrder);
            }
            return orderedEntities;
        }
        private static IOrderedEnumerable<TEntity> ThenBy<TEntity>(this IOrderedEnumerable<TEntity> entities, Func<TEntity, object> valueSelector, SortOrder sortOrder)
        {
            if (sortOrder == SortOrder.Descending)
                return entities.ThenByDescending(valueSelector);
            return entities.ThenBy(valueSelector);
        }
        private static IOrderedEnumerable<TEntity> OrderBy<TEntity>(this IEnumerable<TEntity> entities, Func<TEntity, object> valueSelector, SortOrder sortOrder)
        {
            if (sortOrder == SortOrder.Descending)
                return entities.OrderByDescending(valueSelector);
            return entities.OrderBy(valueSelector);
        }
    }
