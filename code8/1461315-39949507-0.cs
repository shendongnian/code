        string startPath = Application.StartupPath + "\\ContactManager.xml";
        XmlTextReader textReader = new XmlTextReader(startPath);
        string Names = "";
        string sex = "";
        while (textReader.Read())
        {
            switch (textReader.NodeType)
            {
                case XmlNodeType.Element:
                    Names = textReader.Name;
                  if(textReader.Name == "Contact") sex = textReader.GetAttribute("Sex");
                    break;
                case XmlNodeType.Text:
                    Console.WriteLine();
                    lbDisplay.Items.Add(sex + Names + ": " + textReader.Value);
                    break; 
            }
        }
