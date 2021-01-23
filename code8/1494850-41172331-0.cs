    public static class NHExtensions
    {
    	public static IQueryOver<TRoot, TSubType> TransformUsingAliasToBean<TRoot, TSubType>(this IQueryOver<TRoot, TSubType> query, Type resultType)
    	{
    		ITupleSubsetResultTransformer resultTransformer = new AliasToBeanResultTransformer(resultType);
    		var criteria = query.UnderlyingCriteria as NHibernate.Impl.CriteriaImpl;
    		if (criteria != null)
    			resultTransformer = new CacheableAliasToBeenResultTransformer(resultTransformer, criteria.Projection.Aliases);
    		return query.TransformUsing(resultTransformer);
    	}
    
    	class CacheableAliasToBeenResultTransformer : ITupleSubsetResultTransformer
    	{
    		ITupleSubsetResultTransformer baseTransformer;
    		string[] aliases;
    
    		public CacheableAliasToBeenResultTransformer(ITupleSubsetResultTransformer baseTransformer, string[] aliases)
    		{
    			this.baseTransformer = baseTransformer;
    			this.aliases = aliases;
    		}
    
    		public bool[] IncludeInTransform(string[] aliases, int tupleLength)
    		{
    			return baseTransformer.IncludeInTransform(aliases ?? this.aliases, tupleLength);
    		}
    
    		public bool IsTransformedValueATupleElement(string[] aliases, int tupleLength)
    		{
    			return baseTransformer.IsTransformedValueATupleElement(aliases ?? this.aliases, tupleLength);
    		}
    
    		public IList TransformList(IList collection)
    		{
    			return baseTransformer.TransformList(collection);
    		}
    
    		public object TransformTuple(object[] tuple, string[] aliases)
    		{
    			return baseTransformer.TransformTuple(tuple, aliases ?? this.aliases);
    		}
    	}
    }
