        //Serialize using XmlSerializer
    public static bool Serialize<T>(T value, ref StringBuilder sb)
    {
        if (value == null)
            return false;
        try
        {
            XmlSerializer xmlserializer = new XmlSerializer(typeof(T));
            using (XmlWriter writer = XmlWriter.Create(sb))
            {
                xmlserializer.Serialize(writer, value);
                writer.Close();
            }
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }
    //Serialize using DataContractSerializer
    public static bool SerializeDataContract<T>(T value, ref StringBuilder sb)
    {
        if (value == null)
            return false;
        try
        {
            DataContractSerializer xmlserializer = new DataContractSerializer(typeof(T));
            using (XmlWriter writer = XmlWriter.Create(sb))
            {
                xmlserializer.WriteObject(writer, value);
                writer.Close();
            }
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }
    
    //Serialize using StringBuilder
    public static bool SerializeStringBuilder(Employee obj, ref StringBuilder sb)
        {
            if (obj == null)
                return false;
            sb.Append(@"<?xml version=""1.0"" encoding=""utf-16""?>");
            sb.Append("<Employee>");
            sb.Append("<FirstName>");
            sb.Append(SecurityElement.Escape(obj.FirstName));
            sb.Append("</FirstName>");
            //... Omitted for clarity
            sb.Append("</Employee>");
            return true;
        }
    //Serialize using XmlSerializer (manually add elements)
    public static bool SerializeManual(Employee obj, ref StringBuilder sb)
    {
        if (obj == null)
            return false;
        try
        {
            using (var xtw = XmlWriter.Create(sb))
            {
                xtw.WriteStartDocument();
                xtw.WriteStartElement("Employee");
                xtw.WriteStartElement("FirstName");
                xtw.WriteString(obj.FirstName);
                xtw.WriteEndElement();
                //...Omitted for clarity
                xtw.WriteEndElement();
                xtw.WriteEndDocument();
                xtw.Close();
            }
            return true;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }
