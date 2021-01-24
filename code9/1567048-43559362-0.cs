    public class XmlGenerator
    {
        private XmlDocument _document;
        private List<string> _fields;
        private int index = 0;
    
        public XmlGenerator(List<string> fields)
        {
            _fields = fields;
        }
    
        public void GenerateXML(IEnumerable<Foo> lookupData, XmlElement root, string field)
        {
            var fieldGrouping = lookupData.GroupBy(v => v.Bars.First(x => x.Name == field).Value);
            foreach (var grouping in fieldGrouping)
            {
                var element = _document.CreateElement(field);
                var attrib = _document.CreateAttribute("value");
                attrib.InnerText = grouping.Key;
    
                element.Attributes.Append(attrib);
                root.AppendChild(element);
    
                if (index < _fields.Count - 1)
                {
                    index += 1;
                    GenerateXMLFields(grouping, element, _fields[index]);
                    index -= 1;
                }
            }
        }
    
        public string GenerateXML(IEnumerable<Foo> lookupData)
        {
            _document = new XmlDocument();
            var root = _document.CreateElement("Root");
            _document.AppendChild(root);
            index = 0;
    
            GenerateXML(lookupData, root, _fields[index]);
    
            return _document.OuterXml;
        }
    }
