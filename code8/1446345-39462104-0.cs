      private void treeView1_NodeMouseClick_1(object sender,
    > TreeNodeMouseClickEventArgs e)
    >         {
    >             XmlReader reader = null;
    >             reader = XmlReader.Create(filePath);
    >             {
    >                 reader.MoveToContent();
    >                 // Parse the file and display each of the nodes.
    >                 while (reader.Read())
    >                 {
    >                     switch (reader.NodeType)
    >                     {
    >                         case XmlNodeType.Element:
    >                             if (reader.LocalName == "to")
    >                             {
    > 
    >                             }
    >                             break;
    > 
    >                         case XmlNodeType.Text:
    >                             if(reader.Value == "Jane")
    >                             {
    > 
    >                             }
    >                             break;
    >                     }
    >                 }
    >             }
    >         }
    Xml file used is:
    <note>
      <to>Tove</to>
      <from>Jane</from>
      <heading>Reminder</heading>
      <body>Weekend</body>
    </note>
