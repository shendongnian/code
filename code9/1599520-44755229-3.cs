    public class RVD
    {
        public int Id { get; set; }
        public Employee Employee { get; set; } //This will only link to one Employee
        public int PrimaryDriverId { get; set; }
        public int SecondaryDriverId { get; set; }
    }
