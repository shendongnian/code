    public class RequestParameters {
         public IRequest Request { get; set; }
    }    
    public interface IRequest {
         string Username { get; set; }
         string Password { get; set; }
    }
    public interface IRequestWithId : IRequest
    {
        string ID {get; set; }
    }
