    public class ClientAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [ConcurrencyCheck]
        public double Balance { get; set; }
		
		[NotMapped]
        public double OriginalBalance { get; set; }
		
		...
	}
