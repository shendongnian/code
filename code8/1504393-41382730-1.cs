    public partial class login
    {
        public string password { get; set; }
        public string status { get; set; }
        public bool active { get; set; }
        public string emailId { get; set; }
        public int employeeId { get; set; }
        public virtual employedetail employeedetail {get; set;} //Add this in your class
    }
