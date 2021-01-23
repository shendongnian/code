    public class Attendance
    {
        public string WebinarKey { get; set; }
        public string RegistrantKey { get; set; }
        public string TimeInSession { get; set; }
        public int FirstPollCount { get; set; }
        public int SecondPollCount { get; set; }
        public int AttendedWebinar { get; set; }
    }
    
    public class Webinar
    {
        public int PID { get; set; }
        public string FullName { get; set; }
        public List<Attendance> Attendances { get; set; }
    }
    
    public class RootObject
    {
        public List<Webinar> Webinars { get; set; }
    }
