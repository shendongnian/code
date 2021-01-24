    public class Domains
    {
        public Domains() { }
        public Domains(string domain) { this.Domain = domain; }
    
        [PrimaryKey, MaxLength(64)]
        public string Domain { get; set; }
    }
    
    public class Statistics
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Timestamp { get; set; }
    
        [ForeignKey(typeof(Domains))]
        public String DomainId { get; set; }
    
        public int Status { get; set; }
    
        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Domains Domain { get; set; }
    }
