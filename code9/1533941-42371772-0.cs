    public class BaseResponse<T> {
        public T Data { get; set; }
        public Exception Error { get; set; }
    
        public object GetResponse() {
    
            //If an exception has not been thrown then just return your data
            if(Error == null)
                return Data;
            
            //If an exception has been thrown, return the exception
            return Error;
        }
    }  
