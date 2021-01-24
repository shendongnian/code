        [DataContract]
    public class ApiResponse
    {
        [DataMember]
        public bool IsSuccess { get; set; }
        [DataMember]
        public String Message { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public TokenModel Result { get; set; }
        [DataMember]
        public int Status { get; set; }
    
        public ApiResponse() { }
    
        public ApiResponse(bool isSuccess, HttpStatusCode statusCode, string message = null, TokenModel result = null)
        {
            IsSuccess = isSuccess;
            Status = (int)statusCode;
            Result = result;
            Message = message;
        }
    }
 
