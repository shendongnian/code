    public class EModel
    {        
        [Required]
        [Range(0.001, float.MaxValue)]
        [Display(Name = "Long")]
        public string Long { get; set; }
        [Required]
        [Range(0.001, float.MaxValue)]
        [Display(Name = "Lat")]
        public string Lat { get; set; }
    }
