    [System.Serializable]
    [XmlRoot(ElementName = "stats-of-something")]
    public class StatContainer
    {
         [XmlAttribute(AttributeName = "coins")]
         private int _coins = 0;
         [XmlElement(ElementName = "umbrella-speed")]
         private float _umbrellaSpeed = 0.1f;
         public int coins { get { return _coins; } set { _coins = value; } }
         public float umbrellaSpeed  { get { return _umbrellaSpeed ; } set { _umbrellaSpeed = value; } }
    }
