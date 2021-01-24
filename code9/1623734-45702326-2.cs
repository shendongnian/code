    //A single responsibility abstraction
    public interface IClient {
        Task<ResponseObject> CreatesResponse(RequestObject req);
    }
    
    public class ExampleClass {
        private readonly IClient client;
    
        public ExampleClass(IClient client) {
            this.client = client;
        }
        
        public async Task<ResponseObject[]> GetResponses(RequestObject[] arrayOfRequests){
            var arrayOfResponses = await Task.WhenAll(arrayOfRequests
                .Select(req => client.CreatesResponse(req)));
            return arrayOfResponses;
        }
    }
