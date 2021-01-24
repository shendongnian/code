    public class CustomCachingPolicy : CachingPolicy
    {
        protected override bool CanBeCached(ReadOnlyCollection<EntitySetBase> affectedEntitySets, string sql, IEnumerable<KeyValuePair<string, object>> parameters)
        {
            foreach (var entitySet in affectedEntitySets)
            {
                var table = entitySet.Name.ToLower();
                if (table.StartsWith("si_") ||
                    table.StartsWith("dft_") ||
                    table.StartsWith("tt_"))
                    return false;
            }
            return base.CanBeCached(affectedEntitySets, sql, parameters);
        }
    }
