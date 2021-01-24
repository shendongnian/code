    public class FilterController
    {
         [HttpGet]
         [ReadRoute("")]
         public Entity[]  GetList(QueryTreeNode queryRoot, string entityType)
         {
             var type = Assembly.GetExecutingAssembly().GetType(entityType);
             var entities = someRepository.GetType()
                 .GetMethod("GetEntities")
                 .MakeGenericMethod(type)
                 .Invoke(dbContext, queryRoot);
         }
    }
    public class SomeRepository
    {
        public TEntity[] GetAllEntities<TEntity>()
        {
            // Somehow select a collection of entities of given type TEntity
        }
        public TEntity[] GetEntities<TEntity>(QueryTreeNode queryRoot)
        {
            return GetAllEntities<TEntity>()
                .Where(BuildExpression<TEntity>(queryRoot));
        }
        Expression<Func<TEntity, bool>> BuildExpression<TEntity>(QueryTreeNode queryRoot)
        {
            // Expression building logic
        }
    }
