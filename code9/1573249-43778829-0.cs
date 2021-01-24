    class MyError
    {
        public string[] data{get;set;}
        public string error_msg {get;set;}
        public string message {get;set;}
    }
    var response = jss.Deserialize<MyError>(responseValue); 
