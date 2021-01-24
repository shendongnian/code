    public class Data
    {
        public string result { get; set; }
        public int id_user { get; set; }
        public object dob_match { get; set; }
        public object first_name_match { get; set; }
        public object last_name_match { get; set; }
    }
    
    public class RootObject
    {
        public string status { get; set; }
        public Data data { get; set; }
        public int code { get; set; }
    }
