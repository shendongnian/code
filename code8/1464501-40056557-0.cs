    [XmlType("Command")]
    public class CommandXml
    {
        [XmlAttribute("command")]
        public string Command { get; set; }
        [XmlAttribute("response")]
        public string Response { get; set; }
        [XmlAttribute("author")]
        public string Author { get; set; }
        [XmlAttribute("count")]
        public int Count { get; set; }
    }
    [XmlRoot("Commands")]
    public class CommandListXml : List<CommandXml>
    {
    }
