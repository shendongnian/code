    public static string ToXMLString<T>(this T toSerialize)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
        using (StringWriter textWriter = new StringWriter())
        {
            //Create our own namespaces for the output
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            //Add an empty namespace and empty value
            //ns.Add("", "http://www.portalfiscal.inf.br/nfe");
            ns.Add("", "");
            xmlSerializer.Serialize(textWriter, toSerialize, ns);
            return textWriter.ToString();
        }
    }
