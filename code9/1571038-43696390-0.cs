    [Table("Contact")]
    public class ContactModel
    {
        public int Id { get; set; }
        [Required]
        public string  Name { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Email { get; set; }
        [ForeignKey("Image")]
        public int ImageId { get; set; }
        public virtual ImageModel Image { get; set; }
    }
