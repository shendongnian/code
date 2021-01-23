    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        private SupportedLanguages language;
        public SupportedLanguages Language 
        { 
            get { return language; }
            set 
            {
                if(!Enum.IsDefined(typeof(SupportedLanguages), value))
                    throw new ArgumentOutOfRangeException();
                language = value;
            }
        }
    
        [NotMapped]
        public CultureInfo Culture => string.IsNullOrWhiteSpace(Language.GetDescription()) ? Thread.CurrentThread.CurrentCulture : new CultureInfo(Language.GetDescription());
    }
