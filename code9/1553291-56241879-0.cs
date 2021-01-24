public class MyMapper : Profile
{
	public MyMapper()
	{
		// Null collections will be mapped to null collections.
		AllowNullCollections = true;
		CreateMap<MySource, MyDestination>();
	}
}
