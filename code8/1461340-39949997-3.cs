    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public XElement ToXML()
    {
        return new XElement("Person", "Name", Name,
                   new XElement("Age", Age),
                   new XElement("Sex", Sex));
    }
        public Person FromXML(XElement node)
        {
            try { Name = node.Element("Name").Value; }
            catch { Name = "Not Found"; }
            try { Age = Convert.ToInt16(node.Element("Age").Value); }
            catch { Age = -1; }
            try { Sex = node.Element("Sex").Value; }
            catch { Sex = ""; }
            return this;
        }
    }
