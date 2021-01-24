    public class NewRoot
    {
        [XmlElement("MSG", typeof(MSG))]
        [XmlElement("Mg", typeof(Mg))]
        public MSG Msg {get;set;}
    }
    public class Mg : MSG {}
