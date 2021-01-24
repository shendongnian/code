    public class BVSROI
    {
       [Key]
       public int BVSROIId { get; set; }
       [Required]
       public string ROIItem { get; set; }
       public string ROIYear { get; set; }
       public Dictionary<string, double> UserInput { get; set; }
       // Foreign Key
       public int BVSId { get; set; }
       // Navigation property
       public BusinessValue BusinessValue { get; set; }
    }
