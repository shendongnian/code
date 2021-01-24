      static void Main(string[] args)
      {
         using (var xmlStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("ConsoleApp1.XMLFile1.xml"))
         {
            int state = 0; // 0 = Look for xref; 1 = look for separator
            string[] simpleSeparators = { " ", ", " };
            string rid = "0";
            StringBuilder nodeText = new StringBuilder();
            string[] consecutiveNodes = new string[3];
            System.Xml.XmlReaderSettings settings = new System.Xml.XmlReaderSettings();
            settings.DtdProcessing = System.Xml.DtdProcessing.Ignore;
            using (var reader = System.Xml.XmlReader.Create(xmlStream, settings))
            {
               while (reader.Read())
               {
                  if (reader.IsStartElement("xref"))
                  {
                     nodeText.Append("<xref");
                     if (reader.HasAttributes)
                     {
                        while (reader.MoveToNextAttribute())
                           nodeText.AppendFormat(" {0}=\"{1}\"", reader.Name, reader.Value);
                     }
                     nodeText.Append(">");
                     string nextRid = reader.GetAttribute("rid");
                     switch (state)
                     {
                        case 0:
                           break;
                        case 2:
                        case 4:
                           if (GetIndex(nextRid) != GetIndex(rid) + 1)
                              state = 0;
                           break;
                     }
                     state++;
                     rid = nextRid;
                  }
                  else if (reader.NodeType == System.Xml.XmlNodeType.Text)
                  {
                     if (state > 0)
                        nodeText.Append(reader.Value);
                     if ((state % 2 == 1) && simpleSeparators.Contains(reader.Value))
                           state++;
                  }
                  else if ((reader.NodeType == System.Xml.XmlNodeType.EndElement) && (state > 0))
                  {
                     nodeText.AppendFormat("</{0}>", reader.Name);
                     consecutiveNodes[state / 2] = nodeText.ToString();
                     nodeText.Clear();
                     if (state > 3)
                     {
                        Console.WriteLine("{0}{1}{2}", consecutiveNodes[0], consecutiveNodes[1], consecutiveNodes[2]);
                        state = 0;
                     }
                  }
                  else if (reader.IsStartElement())
                  {
                     nodeText.Clear();
                     state = 0;
                  }
               }
            }
         }
      }
      static int GetIndex(string rid)
      {
         int start = rid.Length;
         while ((start > 0) && Char.IsDigit(rid, --start)) ;
         start++;
         if (start < rid.Length)
            return int.Parse(rid.Substring(start));
         return 0;
      }
