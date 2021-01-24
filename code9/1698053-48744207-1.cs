    public class CustomResolver : IValueResolver<Source, Destination, int>
    {
    	public int Resolve(Source source, Destination destination, int member, ResolutionContext context)
    	{
            return source.Value1 + source.Value2;
    	}
    }
