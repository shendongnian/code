    [XmlRoot("monster")]
    public class monster
    {
        public flags flags { get; set; }
    }
    public class flags
    {
        public int summonable { get; set; }
        public int attackable { get; set; }
        // Add more as required.
    }
