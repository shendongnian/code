        string xmlString = string.Empty;
        using (TextWriter writer = new StringWriter())
        {
                table.WriteXml(writer);
                xml = writer.ToString();
        }  
