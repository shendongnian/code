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
    
                // If that is last field. No need to do any grouping.
                if (index < _fields.Count - 1)
                {
                    // After each nested call update the nested level.
                    // If GenerateXML do another that will be upon next nested level
                    index += 1;
                    GenerateXML(grouping, element, _fields[index]);
                    index -= 1;
                    // Make sure to change back nested level index otherwise that will not works if you have multiple groups.
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
