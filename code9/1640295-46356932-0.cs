    public class ApiResponse<T>{
    public T Data {get;set;} // it will contains the response
    public string Message {get;set;} // here you can put you error message
    public boolean IsSuccess {get;set;} //this will be true only when no error
    }
