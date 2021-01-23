    [XmlRoot(Namespace="http://www.....abc")]
    public class EfxTransmit
    {
        public EfxReport EfxReport { get; set; }
    }
    public class EfxReport
    {
        public CNConsumerCreditReports CNConsumerCreditReports { get; set; }
    }
    public class CNConsumerCreditReports
    {
        public CNConsumerCreditReport CNConsumerCreditReport { get; set; }
    }
    public class CNConsumerCreditReport
    {
        // ...
    }
