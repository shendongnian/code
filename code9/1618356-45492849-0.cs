    public class UDF
    {
        [Key]
        public long Id { get; set; }
    
        [Required]
        public string Name { get; set; }
    	
        [Required]
        public string Value { get; set; }
    }
    public class Data
    {
        [Key]
        public long Id { get; set; }
    
        [Required]
        public float Value { get; set; }
    
        [Required]
        public DateTime Timestamp { get; set; }
    
        [Required]
        public List<UDF> UDFs { get; set; }
    }
    string sql = @"SELECT
    		d.Id,
    		d.Value,
    		d.Timestamp,
    		u.name,
    		u.value
    FROM Data d
    INNER JOIN UDFTable u ON d.Id = u.Id";
