    [Serializable]
    public class root
    {
        [System.Xml.Serialization.XmlElementAttribute("new")]
        public Node[] @new { get; set; }
    }
    
    [Serializable]
    public class Node
    {
        public string Status { get; set; }
        public string Company { get; set; }
        //other properties
    }
