    public class Student 
    {
        public int StudentID { get; set; }
        
        public int CurrentStandardId { get; set; }
        public int PreviousStandardId { get; set; }
        [ForeignKey("CurrentStandardId")]
        public Standard CurrentStandard { get; set; }
        
        [ForeignKey("PreviousStandardId")]
        public Standard PreviousStandard { get; set; }
    }
