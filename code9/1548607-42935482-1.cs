    [DataContract]
    public class ProjektStammdaten
    {
        [DataMember]
        public DateTime AeTerminStammhaus { get; set; }
        
        [DataMember]
        public DateTime? AeTerminTochter { get; set; }
