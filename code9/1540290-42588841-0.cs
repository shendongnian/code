	public class RestDataConverter<TSource, TDestination> : ITypeConverter<RestData<TSource>, RestData<TDestination>>
	{
		public RestData<TDestination> Convert(RestData<TSource> source, RestData<TDestination> destination, ResolutionContext context)
		{
			destination = destination ?? new RestData<TDestination>();
			destination.SetData(context.Mapper.Map<TDestination>(source.Data));
			destination.SetPaging(source.Paging);
			return destination;
		}
	}
