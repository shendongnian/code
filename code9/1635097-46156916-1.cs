    public class MyEntity
    {
        [Key]
        public Guid Id { get; set; }
        // Add a timestamp property to your class
        [JsonIgnore]
        [Timestamp]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [ConcurrencyCheck]
        public byte[] VersionTimestamp { get; set; }
        public int Counter { get; set; }
    }
