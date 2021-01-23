    public byte[] GetDocumentHash(XmlDocument doc)
    {
        string formattedXml;
        Transform canonicalTransform = new XmlDsigExcC14NWithCommentsTransform();
        canonicalTransform.LoadInput(doc);
        using (Stream canonicalStream = (Stream)canonicalTransform.GetOutput(typeof(Stream)))
        using (var stringWriter = new EncodingStringWriter(Encoding.UTF8))
        using (var xmlTextWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { NewLineChars = "\n", CloseOutput = false, Encoding = Encoding.UTF8, Indent = true, OmitXmlDeclaration = true }))
        {
            XmlDocument newDoc = new XmlDocument();
            newDoc.Load(canonicalStream);
            newDoc.WriteTo(xmlTextWriter);
            xmlTextWriter.Flush();
            formattedXml = stringWriter.GetStringBuilder().ToString();
        }
        byte[] bytesToCalculate = Encoding.UTF8.GetBytes(formattedXml);
        using (var sha256 = SHA256.Create())
        {
            byte[] shaBytes = new byte[bytesToCalculate.Length];
            bytesToCalculate.CopyTo(shaBytes, 0);
            sha256.TransformFinalBlock(shaBytes, 0, shaBytes.Length);
            return sha256.Hash;
        }
    }
