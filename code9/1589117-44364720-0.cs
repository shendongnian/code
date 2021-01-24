    // Used for communication between WCF and client. Must be implemented both WCF and client sides
    public class Response {
     public int Id { get; set; }
     public string Data { get; set; }
    }
    
    // Web Service - Interface
    [ServiceContract]
    public interface IService
    {
          [OperationContract]
          [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "Up")]
          string CheckLogin();
    }
        
    // Web service - Implementation
    public class ServiceImplementation : IService
    {
      public Response isUp()
      {
             Response response = new Response();
             response.ID = 200;
             response.Data = "web service is up";
             return response;
      }
    }
