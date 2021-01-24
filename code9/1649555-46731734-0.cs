    public class Data
    {
        public int StaffID { get; set; }
        public string StaffSurname { get; set; }
        public string StaffForename { get; set; }
        public string StaffEmail { get; set; }
        public int PrimaryStaffRoleID { get; set; }
        public string TokenApi { get; set; }
    }
    
    public class RootObject
    {
        public int code { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }
