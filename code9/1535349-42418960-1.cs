    public class Responses 
    {
    	// Some code here
    	public bool IsSuccess { get; set; }
    	public string ResponseMessage { get; set; }
    }
    
    public interface IResponsesContainer
    {
    	Responses Responses { get; set; }
    }
    
    public class GetDictionaryplResponse : IResponsesContainer
    {
    	public Responses Responses { get; set; }
    }
    
    public enum ResponsesTypes
    {
    	NullFound
    }
    
    public static class ResponsesFactory 
    {
    	public static IResponsesContainer CreateContainer<TContainer>(ResponsesTypes responsesType)
    		where TContainer : IResponsesContainer, new()
    	{
    		var container = new TContainer();
    		switch(responsesType)
    		{
    			case ResponsesTypes.NullFound:
    				container.Responses = new Responses()
    		        {
    		            IsSuccess = false,
    		            ResponseMessage = "There response data is invalid!"
    		        };
    				return container;
    			default:
    				throw new NotImplementedException();
    		}
    	}
    }
