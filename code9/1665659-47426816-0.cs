    public class tbl_employee
    {
        public string emp_Disease { get; set; }
        public List<Disease> Disease { get; set; }
    }
    
    public class Disease
    {
        public int id { get; set; }
        public string Name { get; set; }
        public bool emp_Disease { get; set; }
    }
