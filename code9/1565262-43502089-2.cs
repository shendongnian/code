    private bool ConvertFile(string infile, string outfile)
    {
        Guid g = Guid.NewGuid();
        string filename = Path.GetFileName(infile);
        string name = Path.GetFileNameWithoutExtension(infile);
        string description = "";
        string nontransrule = "123456\r\n123456\r\n123456\r\n123456";
        using (MemoryStream ms = new MemoryStream())
        {
            XmlTextWriter writer0 = new XmlTextWriter(ms, Encoding.UTF8);
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
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            MemoryStream ms2 = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(ms2, settings);
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
            FileStream fs = new FileStream(outfile, FileMode.Create);
            ms.Seek(0, SeekOrigin.Begin);
            ms2.Seek(0, SeekOrigin.Begin);
            ms.WriteTo(fs);
            byte []byCR = Encoding.UTF8.GetBytes("\r\n"); // encoding not really needed, could have specified the raw \r\n bytes
            fs.Write(byCR, 0, byCR.Length);
            ms2.WriteTo(fs);
            fs.Close();
        }
        return false;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        ConvertFile("dot.txt", "S:\\test.xml");
    }
