    public class absence
    {
        public int absenceCode { get; set; }
        public int typeAbsence { get; set; }
        public DateTime startingDate { get; set; }
        public DateTime endingDate { get; set; }
        public string description { get; set; }
        public string state { get; set; }
    }
    public class person
    {
        public int personCode { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public int maxHolidayDays { get; set; }
        // Initialize in constructor if you have an error
        public List<absence> absences { get; set; } = new List<absence>();
    }
