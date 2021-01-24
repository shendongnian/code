    public class MyEntity
    {
        [Key]
        public Guid Id { get; set; }
        // Add a timestamp property to your class
        [Timestamp]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [ConcurrencyCheck]
        public byte[] VersionTimestamp { get; set; }
        public int Counter { get; set; }
    }
