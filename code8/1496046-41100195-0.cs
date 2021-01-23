    public static IEnumerable<TView> MapEnumerable<TDomainModel, TView>(this IEnumerable<TDomainModel> domainEnumerable)
    			where TDomainModel : class
    			where TView : class
    		{
    			return AutoMapper.Mapper.Map<IEnumerable<TDomainModel>, IEnumerable<TView>>(domainEnumerable);
    		}
