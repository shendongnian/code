    public class Arm
    {
        [XmlElement("ID")]
        [XmlDescription(Value = "It defines ID number of the Arm")]
        public int ID { get; set; }
        [XmlElement("Store")]
        [XmlDescription(Value = "It defines the Store of the Arm")]
        public ArmStore Store { get; set; }
        [XmlElement("Dimension")]
        [XmlDescription(Value = "It defines the dimension of the Arm")]
        public ArmDimension Dimension { get; set; }
    }
