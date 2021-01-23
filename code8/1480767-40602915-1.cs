    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        public SupportedLanguages Language { get; set; }
    
        [NotMapped]
        public CultureInfo Culture => string.IsNullOrWhiteSpace(Language.GetDescription()) ? Thread.CurrentThread.CurrentCulture : new CultureInfo(Language.GetDescription());
    }
