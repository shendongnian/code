    using System; 
    namespace MyProject.Api_Models
    {
        public class ApiResponse
        {
            public bool Status { get; set; }
            public Object Data { get; set; }
            public string Message { get; set; }
        }
    }
