    public class TBaseModel
    {
        public void ConfigureMapFrom(IMappingExpression<TEntity, TBaseModel> mapping)
        {
            // ... mappings
        }
    }
    
    public class TModel : TBaseModel
    {
        public void ConfigureMapFrom(IMappingExpression<TEntity, TModel> mapping)
        {
            mapping.IncludeBase<TEntity, TBaseModel>();
        
            // ... other mappings
        }
    }
