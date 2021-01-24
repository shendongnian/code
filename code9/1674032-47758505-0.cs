    [Serializable]
    public class ObjectSerialize :  IXmlSerializable
    {
        public List<object> ObjectList { get; set; }
        public XmlSchema GetSchema()
        {
            return new XmlSchema();
        }
        public void ReadXml(XmlReader reader)
        {
            
        }
        public void WriteXml(XmlWriter writer)
        {
            foreach (var obj in ObjectList)
            {   
                //Provide elements for object item
                writer.WriteStartElement("Object");
                var properties = obj.GetType().GetProperties();
                foreach (var propertyInfo in properties)
                {   
                    //Provide elements for per property
                    writer.WriteElementString(propertyInfo.Name, propertyInfo.GetValue(obj).ToString());
                }
                writer.WriteEndElement();
            }
        }
    }
