    public static class HandleResponse {
            public static void AddException<T>( Exception ex, ref ResponseList<T> response) {
                response.ResposeCode = ResposeCodes.Error;
                response.Exceptions.Add(ResposeCodes.Error.ToString(), ex.Message);
    
    
                //inserting errors into table                
    
            }
    
            public static void AddErrorMessage<T>( string message, ref ResponseList<T> r ) {
                r.ResposeCode = ResposeCodes.Error;
                r.ResponseMessage = message;
            }
    
            public static void AddSuccessMessage<T>( string message, ref ResponseList<T> r ) {
                r.ResposeCode = ResposeCodes.Success;
                r.ResponseMessage = message;
            }
        }
