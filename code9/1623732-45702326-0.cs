    //A single responsibility abstraction
    public interface IResponseFactory {
        Task<ResponseObject> FunctionThatCreatesResponse(RequestObject req);
    }
    
    public class ExampleClass {
        private readonly IResponseFactory factory
    
        public ExampleClass(IResponseFactory factory) {
            this.factory = factory;
        }
        
        public async Task<ResponseObject[]> GetResponses(RequestObject[] arrayOfRequests){
            var arrayOfResponses = await Task.WhenAll(arrayOfRequests
                .Select(req => factory.FunctionThatCreatesResponse(req)));
            return arrayOfResponses;
        }
    }
