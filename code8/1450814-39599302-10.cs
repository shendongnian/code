    public static class ExtensionClass
    {
        // we inform compiler that this method extends any type that is derived from base type
        public static TEntity ChangeName<TEntity>(this TEntity entity, string newName)
           where T : BaseClient            
        {
            entity.FirstName = newName;
            return entity;
        }
        public static TResult ToModel<TEntity, TResult>(this TEntity entity)
           where TEntity : BaseClient
           where TResult : BaseClient, new()
        {
            var result = new TResult();
            result.FirstName = entity.FirstName; 
            // ... rest of binding operations goes here
            return result;
        }
    }
