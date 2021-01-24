    public class Domains
    {
        public Domains() { }
        public Domains(string domain) { this.Domain = domain; }
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique, MaxLength(64)]
        public string Domain { get; set; }
    }
    public class Statistics
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Timestamp { get; set; }
        public int DomainId { get; set; }
        public int Status { get; set; }
    }
    // Virtual Table
    public class StatisticsView
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Timestamp { get; set; }
        public string Domain { get; set; }
        public int Status { get; set; }
    }       
