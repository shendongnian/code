    public class BaseResponse<T> where T: object {
      public T Data {get;set;}
      public bool Success {get; set;}
      public IList<Error> Errors {get;set;}
    }
