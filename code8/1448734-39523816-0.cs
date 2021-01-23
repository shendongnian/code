    public abstract class flag
    {
    
    }
    
    public class summonableFlag : flag
    {
        [XmlAttribute("summonable")]
        public int summonable { get; set; }
    }
    
    public class attackableFlag : flag
    {
        [XmlAttribute("attackable")]
        public int attackable { get; set; }
    }
