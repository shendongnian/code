    public class AddGroupViewModel
    {
        [Required]
        [Display(Name = "Subject")]
        public string subject_name { get; set; }
    
        [Required]
        [Display(Name = "Number of Groups")]
        public int qty { get; set; }
        public List<Subject> Subjects { get; set; }
    }
