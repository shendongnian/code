    public class SpecificRequestA : ApiRequest {}
    public class SpecificResponseA : ApiResponse{}
    
    public interface IRequestHander<TRequest,TResponse>
        where TRequest : ApiRequest
        where TResponse : ApiResponse
    {
        TResponse Exeute(TRequest request);
    }
    
    public class SpecificRequestHandlerA : IRequestHander<SpecificRequestA,SpecificResponseA>
    {
        SpecificResponseA Execute(SpecificRequestA request)
        {
            //create the new response out of the given request. Here you know exactly on what you are working :)
        }
    }
