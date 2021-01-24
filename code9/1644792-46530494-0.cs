      [XmlRoot(ElementName = "Dynamic", Namespace = "http://seedmaster.ca/")]
        public class SeedPlanWayPoint
        {
            [XmlElement("Bin1SeedRate")]
            public float Bin1SeedRate { get; set; }
            [XmlElement("Bin2SeedRate")]
            public float Bin2SeedRate { get; set; }
            [XmlElement("Bin3SeedRate")]
            public float Bin3SeedRate { get; set; }
            [XmlElement("Bin4SeedRate")]
            public float Bin4SeedRate { get; set; }
            [XmlElement("OpenersPackingPressure")]
            public float OpenersPackingPressure { get; set; }
            public SeedPlanWayPoint() { }
        }
