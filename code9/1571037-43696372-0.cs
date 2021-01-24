    [Table("Contact")]
    public class ContactModel
    {
        public int Id { get; set; }
        [Required]
        public string  Name { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Email { get; set; }
    
        //Foreign key for Image
        public int ImageId { get; set; }
    
        [ForeignKey("ImageId")]
        public virtual ImageModel Image { get; set; }
    }
    [Table("ContactImage")]
    public class ImageModel
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
    }
