    public void WriteXml(XmlWriter writer)
        {
            foreach (PropertyInfo property in GetType().GetProperties())
            {
                writer.WriteElementString(property.Name, property.GetValue(this)?.ToString());
            }
        }
