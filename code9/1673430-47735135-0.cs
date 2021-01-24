    private void Serializer_UnknownElement(Object sender, XmlElementEventArgs e)
    {
        var device = e.ObjectBeingDeserialized as Device;
        if (device != null)
        {
            XmlElement element = e.Element;  
            using (StringReader reader = new StringReader(element.OuterXml))
            {
                XmlSerializer valueSerializer = new XmlSerializer(typeof(Value), (new XmlRootAttribute(element.Name)));
                Value value = (Value)valueSerializer.Deserialize(reader);
                value.Name = element.Name; // implement it so you can rebuild the tag back
                device.Values.Add(value);
            }
        }
    }
