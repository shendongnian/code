    public class CarImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int CarID { get; set; }
        [ForeignKey("CarID")]
        public virtual Car Car { get; set; }
        public string FileName { get; set; }
    }
