    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarID { get; set; }
        [Required]
        public string Title { get; set; }
        public int? PrimaryImageID { get; set; }
        [ForeignKey("CarImageID")]
        public virtual CarImage PrimaryImage { get; set; }
    }
