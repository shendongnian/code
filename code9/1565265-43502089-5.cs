    private bool ConvertFile(string infile, string outfile)
    {
        Guid g = Guid.NewGuid();
        string filename = Path.GetFileName(infile);
        string name = Path.GetFileNameWithoutExtension(infile);
        string description = "";
        string nontransrule = "123456\r\n123456\r\n123456\r\n123456";
        using (FileStream fs = new FileStream(outfile, FileMode.Create))
        {
            XmlTextWriter writer0 = new XmlTextWriter(fs, Encoding.UTF8);
            writer0.Formatting = Formatting.Indented;
            writer0.WriteStartElement("MemoQResource");
            writer0.WriteAttributeString("ResourceType", "NonTrans");
            writer0.WriteAttributeString("Version", "1.0");
            writer0.WriteStartElement("Resource");
            writer0.WriteElementString("Guid", Convert.ToString(g));
            writer0.WriteElementString("FileName", filename);
            writer0.WriteElementString("Name", name);
            writer0.WriteElementString("Description", description);
            writer0.WriteEndElement();
            writer0.WriteEndElement();
            writer0.Flush();
        }
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = "\t";
        using (StreamWriter sr = new StreamWriter(outfile, true, Encoding.UTF8))
        {
            sr.WriteLine();
            using (XmlWriter writer = XmlWriter.Create(sr, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("nonTrans");
                writer.WriteAttributeString("Version", "1.0");
                string[] words = nontransrule.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (string word in words)
                {
                    writer.WriteElementString("nonTransRule", word);
                }
                writer.WriteEndElement();
                writer.Flush();
            }
        }
        return false;
    }
