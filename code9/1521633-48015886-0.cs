    public class Configuration
    {
        [Key]
        public int ClientId { get; set; }
        public CommunicationType CommunicationType { get; set; }
        public string CommunicationValue { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
    }
