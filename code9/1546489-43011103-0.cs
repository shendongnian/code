    [DataContract(Namespace = "")]
    public abstract class OutputHeaderBase
    {
        [DataMember(Name = "FAULT", Order = 1)]
        public Fault FaultSection { get; set; }
        [DataMember(Name = "CNL-OUT", Order = 2)]
        public string ClnOut { get; set; }
    }
    [DataContract(Name = "OUTPUT-HEADER", Namespace = "http://aaa.bbb.ccc/v2")]
    public class OutputHeader : OutputHeaderBase
    {
    }
    [DataContract(Name = "FAULT", Namespace = "http://aaa.bbb.ccc/v2")]
    public class Fault
    {
        [DataMember(Name = "COD-ERROR", Order = 1)]
        public int CodigoError { get; set; }
        [DataMember(Name = "COD-SEV", Order = 2)]
        public int Severidad { get; set; }
        [DataMember(Name = "MSG-ERROR", Order = 3)]
        public string Mensaje { get; set; }
    }
