        public static TResult ToModel<TEntity, TResult>(this TEntity entity)
           where TEntity : BaseClient
           where TResult : BaseClient, new()
        {
            var result = new TResult();
            result.FirstName = entity.FirstName; 
            // ... rest of binding operations goes here
            return result;
        }
