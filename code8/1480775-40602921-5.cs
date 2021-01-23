    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        public string Language { get; protected set; }
        
        public setLanguage(string value)
        {
            if(new[]{"sl-SI", "hr-HR", "ru-RU"}.Contains(value))
                Language = value;
        }
    
        [NotMapped]
        public CultureInfo Culture => string.IsNullOrWhiteSpace(Language) ? Thread.CurrentThread.CurrentCulture : new CultureInfo(Language);
    }
