    [System.Serializable]
    [XmlRoot(ElementName = "stats-of-something")]
    public class StatContainer
    {
         [XmlAttribute(AttributeName = "coins")]
         public int coins = 0;
         [XmlElement(ElementName = "umbrella-speed")]
         public float UmbrellaSpeed = 0.1f;
    }
