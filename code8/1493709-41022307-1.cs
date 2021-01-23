    [XmlRoot(Namespace="http://www.....abc")]
    public class EfxTransmit
    {
        public class EfxReport EfxReport { get; set; }
    }
    public class EfxReport
    {
        public class CNConsumerCreditReports CNConsumerCreditReports { get; set; }
    }
    public class CNConsumerCreditReports
    {
        public CNConsumerCreditReport CNConsumerCreditReport { get; set; }
    }
    public class CNConsumerCreditReport
    {
        // ...
    }
