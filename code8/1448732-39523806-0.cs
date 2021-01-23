    [XmlRoot("monster")]
    public class monster
    {
        public List<flag> flags { get; set; }
    }
    public class flag
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
    
        [XmlAttribute("Value")]
        public string Value { get; set; }
        
    }
 
    public void XML() { 
        monster monster = new monster
        {
                flags = new List<flag>
                {
                    new flag() { Name="summonable", Value = 0 },
                    new flag() { Name="attackable", Value =0 }
                }
            };
         }
