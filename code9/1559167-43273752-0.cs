    public void loopPropXML<T>(IEnumerable<T> queryResult, PropertyInfo[] properites, List<string> addedValues, XmlTextWriter xWriter)
    {
        foreach (var qrl in queryResult)
        {
            var values = new List<object>();
            xWriter.WriteStartElement("tv");
            foreach (var property in properites)
            {
                Object value = property.GetValue(qrl, null);
                xWriter.WriteStartElement(property.Name.ToString());
                xWriter.WriteString(value.ToString());
                xWriter.WriteEndElement();
                values.Add(value);
            }
            xWriter.WriteEndElement();
        }
    }
