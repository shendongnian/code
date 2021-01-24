    public partial class RemoteServiceTypePart1
    {
        // Tell the Xml serializer to use "List" instead of "List_Override" 
        // as the element name.  
        [XmlAnyElement("List")]
        public XElement List_Override
        {
            get {
                var result = new List<XElement>(); 
    
                for (int i = 0; i < List.Name.Length; i++)
                {
                    result.Add(new XElement("Name", List.Name[i]));
                    result.Add(new XElement("Data", List.Data[i]));
                    result.Add(new XElement("OtherData", List.OtherData[i]));
                }
    
                return new XElement("List", result.ToArray());
            }
    
            set { }
        }
    }
