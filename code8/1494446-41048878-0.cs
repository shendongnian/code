    public class project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        [Required]
        public string aliasName { get; set; }
        [ForeignKey("Features")]
        public virtual List<int> featureIds { get; set; }
    }
