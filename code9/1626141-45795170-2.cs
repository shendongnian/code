    public class DataStack1
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int id { get; set; }
        public string somedata { get; set; }
    }
    public class DataStack2
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int id { get; set; }
        public int DataStack1id { get; set; }
        public DataStack1 DataStack1 { get; set; }
        public string somedata { get; set; }
    }
