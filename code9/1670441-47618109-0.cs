    namespace SATA_DTOs
    {
        [DataContract(Name = "ArrayOfPI")]
        public class ArrayOfPI
        {
            [DataMember] public string ordId { get; set; }
            [DataMember] public string fnm { get; set; }
            [DataMember] public string lnm { get; set; }
            [DataMember] public string fthNm { get; set; }
            [DataMember] public string pId { get; set; }
            [DataMember] public string sex { get; set; }
            [DataMember] public string brthD { get; set; }
            [DataMember] public string addrs { get; set; }
            [DataMember] public string nId { get; set; }
            [DataMember] public string srvNm { get; set; }
            [DataMember] public string rfrPhy { get; set; }
        }
    }
