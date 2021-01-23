    public class CarImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarImageID { get; set; }
        [Required]
        public int CarID { get; set; }
        [ForeignKey("CarID")]
        [Required]
        public virtual Car Car { get; set; }
        public string FileName { get; set; }
    }
