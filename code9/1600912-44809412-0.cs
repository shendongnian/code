    [DataContract]
    public class testroot
    {
        private testTimedict _results;
        [DataMember(Name = "results")]
        public testTimedict Results { get; set; }
    }
    [DataContract]
    public class testTimedict
    {
        private Dictionary<string, TimeSheets> _timesheet;
        [DataMember(Name = "timesheets")]
        public Dictionary<string, TimeSheets> timesheetList { get; set; }
    }
    [DataContract]
    public class TimeSheets
    {
        private int _id;
        private int _user_id;
        private int _jobcode_id;
        [DataMember(Name = "id")]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        [DataMember(Name = "user_id")]
        public int user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }
        [DataMember(Name = "jobcode_id")]
        public int jobcode_id
        {
            get { return _jobcode_id; }
            set { _jobcode_id = value; }
        }
    }
