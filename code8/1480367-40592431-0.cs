    public interface IRequest
    {
    }
    public interface IRequest<T> : IRequest
    {
    	T Data { get; set;}
    }
    
    public static class Mapper 
    { 
        public static TOut CreateRequest<TOut>() where TOut : IRequest, new() 
        {
    		return new TOut();
        }
    	
    	public static IRequest<TDto> From<TDto,TModel>(this IRequest<TDto> request, TModel data)
    	{
    		request.Data=Map<TModel,TDto>(data);
    		return request;
    	}
    	public static TOut Map<TIn,TOut>(TIn input)
    	{
    		// Only for this example, you need to provide your own implemenation.
    		return (TOut)(object)((Model)(object)input).Value;
    	}
    
    }
