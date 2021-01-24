    class ApiResponse{
        public object Response {get; set;}
        public ResponseStatus Status{get; set;}
    }
    class ResponseStatus {
        public StatusDetail Detail{get; set;}
        public bool Success {get; set;}
    }
    class StatusDetail {
        public ErrorMessage[] ErrorMessage{get; set;}
    }
    class ErrorMessage{
        public string FieldName{get; set;}
        public string ErrorMessage{get; set;}
        public string ErrorCode{get; set;}
    }
