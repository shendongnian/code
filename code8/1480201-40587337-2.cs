      private void create_node(string num, string id, string age,string date, XmlTextWriter writer)
        {
            writer.WriteStartElement("Table");
            writer.WriteStartElement("MD_Num");
            writer.WriteString(num);
            writer.WriteEndElement();
            writer.WriteStartElement("MD_ID");
            writer.WriteString(id);
            writer.WriteEndElement();
            writer.WriteStartElement("MD_Age");
            writer.WriteString(age);
            writer.WriteEndElement();
            writer.WriteStartElement("MD_Date");
            writer.WriteString(date);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
