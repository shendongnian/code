    using (XmlReader reader = XmlReader.Create(@"C:\A.html"))
    {
         bool isNextNode = true;
         // Loop over all xml tags 
         while (isNextNode)
         {
              // Check we have a div whith attribute class = phone
              if(reader.Name == "div" && reader.GetAttribute("class") == "phone")
              {
                   // Yes, so read until the corresponding closing tag and output content
                   textBox1.AppendText(reader.ReadInnerXml() + Environment.NewLine);
              }
              else
              {
                   // No, read to next tag
                   isNextNode = reader.Read();
              }
         }
    }
