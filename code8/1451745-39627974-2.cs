    public class Solve
    {
        public int SolveID { get; set; }
    
        [ForeignKey("Location")]
        public int LocationID { get; set; }
        public virtual Location Location { get; set; }
           
        [ForeignKey("Profile")]
        public int ProfileID { get; set; }
        public virtual Profile Profile { get; set; }
        [ForeignKey("Bill")]
        public int BillID { get; set; }
        public virtual Bill Bill { get; set; }
        [ForeignKey("Panel")]
        public int? PanelID { get; set; }
        public virtual Panel Panel { get; set; }
    }
