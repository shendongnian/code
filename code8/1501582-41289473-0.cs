    public class Employee : IXmlSerializable
    {
        public int Id { get; set; }
        public PhoneNumber[] Numbers { get; set; }
        
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement("Employee");
            reader.ReadStartElement("Id");
            Id = reader.ReadContentAsInt();
            reader.ReadEndElement();    // Id
            reader.ReadStartElement("Numbers");
            List<PhoneNumber> numbers = new List<PhoneNumber>();
            while (reader.MoveToContent() == XmlNodeType.Element)
            {
                PhoneNumber num = new PhoneNumber();
                num.ReadXml(reader);
                numbers.Add(num);
            }
            Numbers = numbers.ToArray();
            reader.ReadEndElement();    // Numbers
            reader.ReadEndElement();    // Employee
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Id");
            writer.WriteValue(Id);
            writer.WriteEndElement();
            writer.WriteStartElement("Numbers");
            foreach (PhoneNumber num in Numbers)
            {
                num.WriteXml(writer);
            }
            writer.WriteEndElement();   // Numbers
        }
    }
