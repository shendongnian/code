    public class ItemAdditionalPropertyContainer<TModel>
    {
    	public TModel Item { get; set; }
    	public string PropertyValue { get; set; }
    }
    
    public static IQueryable<ItemAdditionalPropertyContainer<TModel>> GetItemsWithAdditionalProperty<TModel>(
    	IQueryable<TModel> items,
    	Expression<Func<TModel, string>> additionalPropertySelector) where TModel : CaloriesEntries
    {
    	Expression<Func<TModel, ItemAdditionalPropertyContainer<TModel>>> expr = 
    		item => new ItemAdditionalPropertyContainer<TModel> 
    			{ 
    				Item = item, 
    				PropertyValue = additionalPropertySelector.Compile()(item)
    			};
    	return items.Select(expr.ExpandExpressions() );
    }
