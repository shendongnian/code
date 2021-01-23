    public class EditBusinessVm
    {
        public int Id { get; set; }
    
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    
        [Required]
        public Address address { get; set; }
    
        [Required]
        [StringLength(20)]
        public string Phone { get; set; }
    
        public HttpPostedFileBase BioPhoto { set;get;}
    
        // Add other properties as needed.
    }
