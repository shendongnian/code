    public static class CommonMappings
    {
    	public static IMappingExpression<TSource, TDestination> MapToBaseViewModel<TSource, TDestination>(this IMappingExpression<TSource, TDestination> map)
    		where TDestination : BaseViewModel
    	{
    		return map
    			.ForMember(dest => dest.Fulladdress, opt => opt.MapFrom("address"))
    			.ForMember(dest => dest.Fullname, opt => opt.MapFrom("name"));
    	}
    }
