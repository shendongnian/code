    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public int? PrimaryImageID { get; set; }
        [ForeignKey("PrimaryImageID")]
        public virtual CarImage PrimaryImage { get; set; }
        public virtual ICollection<CarImage> Images { get; set; }
    }
