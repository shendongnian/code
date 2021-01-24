    int maxRecCountLength = 10; // int.MaxValue.ToString().Length
    int maxRecLengthLength = 10; // int.MaxValue.ToString().Length
    string reservedSpace = new string('+', maxRecCountLength + maxRecLengthLength - 4); // 4 == $1 + $2, see below what $1 and $2 are
    // You have to manually open the FileStream
    using (var fs = new FileStream("out.xml", FileMode.Create))
    // and add a StreamWriter on top of it
    using (var sw = new StreamWriter(fs, Encoding.UTF8, 4096, true))
    {
        // Here you write on your StreamWriter however you want.
        // Note that recCount and recLength have a placeholder $1 and $2.
        int count = 0;
        int maxRecLength = 0;
        using (var xw = XmlWriter.Create(sw))
        {
            xw.WriteWhitespace("\r\n");
            xw.WriteStartElement("Table");
            xw.WriteAttributeString("recCount", "$1");
            xw.WriteAttributeString("recLength", "$2");
            // You have to add some white space that will be 
            // partially replaced by the recCount and recLength value
            xw.WriteWhitespace("\r\n");
            xw.WriteComment("Reserved space:" + reservedSpace);
            // You'll move your Rec writing code here
            for (int i = 0; i < 100; i++)
            {
                xw.WriteWhitespace("\r\n");
                xw.WriteStartElement("Rec");
                string str = string.Format("Some number: {0}", i);
                if (str.Length > maxRecLength)
                {
                    maxRecLength = str.Length;
                }
                xw.WriteValue(str);
                count++;
                xw.WriteEndElement();
            }
            xw.WriteWhitespace("\r\n");
            xw.WriteEndElement();
        }
        sw.Flush();
        // Now we read the first lines to modify them (normally we will
        // read three lines, the xml header, the <Table element and the
        // <-- Reserved space:
        fs.Position = 0;
        var lines = new List<string>();
        using (var sr = new StreamReader(fs, sw.Encoding, false, 4096, true))
        {
            while (true)
            {
                string str = sr.ReadLine();
                lines.Add(str);
                if (str.StartsWith("<Table"))
                {
                    // We read the next line, the comment line
                    str = sr.ReadLine();
                    lines.Add(str);
                    break;
                }
            }
        }
        string strCount = XmlConvert.ToString(count);
        string strMaxRecLength = XmlConvert.ToString(maxRecLength);
        // We do some replaces for the tokens
        int oldLen = lines[lines.Count - 2].Length;
        lines[lines.Count - 2] = lines[lines.Count - 2].Replace("=\"$1\"", string.Format("=\"{0}\"", strCount));
        lines[lines.Count - 2] = lines[lines.Count - 2].Replace("=\"$2\"", string.Format("=\"{0}\"", strMaxRecLength));
        int newLen = lines[lines.Count - 2].Length;
        // Remove spaces from reserved whitespace
        lines[lines.Count - 1] = lines[lines.Count - 1].Replace(":" + reservedSpace, ":" + new string('#', reservedSpace.Length - newLen + oldLen));
        // We move back to just after the UTF8/UTF16 preamble
        fs.Position = sw.Encoding.GetPreamble().Length;
        // And we rewrite the lines
        foreach (string str in lines)
        {
            sw.Write(str);
            sw.Write("\r\n");
        }
    }
