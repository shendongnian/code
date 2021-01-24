    public Results results { get; set; }
    public class Timesheet
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int jobcode_id { get; set; }
    }
    
    public class Results
    {
        public List<Timesheet> timesheets { get; set; }
    }
