    public class StudentWebAccess
    {
        public int StudentID { get; set; }
        public string Gender { get; set; }
        public int Grade { get; set; }        
        public int IPAddress { get; set; } // Also ErrorIPAddress?
        public DateTime DateTime { get; set; }
        public string Action { get; set; }
        public string Code { get; set; } // Also ErrorMessage?
        public string ErrorMessage { get; set; }
    }
