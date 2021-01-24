    public class BusinessValue
    {
        [Key]
        public int BVSId { get; set; }
        public List<BVSROI> BVSROI { get; set; }
    }
    public class BVSROI
    {
        [Key]
        public int BVSROIId { get; set; }
        [Required]
        public string ROIItem { get; set; }
        public UserInput UserInputs { get; set; }
        // Foreign Key
        public int BVSId { get; set; }
        // Navigation property
        public BusinessValue BusinessValue { get; set; }
    }
    public class UserInput
    {
        public int Initial { get; set; 
        public int year1 { get; set; }
        public int year2 { get; set; }
        public int year3 { get; set; }
    }
