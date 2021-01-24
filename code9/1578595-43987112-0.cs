    XmlNode node = doc.DocumentElement.SelectSingleNode("/para");
    Console.WriteLine(node.Name);
    foreach (XmlNode n in node.ChildNodes)
    {
      if (n.Name == "para" || n.Name == "emphasis" || n.Name == "subject")
      {
        if (!String.IsNullOrWhiteSpace(n.InnerText))
        {
          Console.WriteLine(n.Name + " - " + n.InnerText);
        }
      }
    }
