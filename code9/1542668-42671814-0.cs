    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.Load("YOUR_PATH_TO_XML");
    //for sftp1
    XmlNodeList sftp1_hd = xmlDoc.GetElementsByTagName("sftp1");
    foreach (XmlNode sftp1_node in sftp1_hd)
    {
      foreach (XmlNode sftp1_child_nodes in sftp1_node.ChildNodes)
      {
        Console.WriteLine(sftp1_child_nodes.LocalName);
        Console.WriteLine(sftp1_child_nodes.InnerText);
      }
      
    }
    
    //for sftp2
    XmlNodeList sftp2_hd = xmlDoc.GetElementsByTagName("sftp2");
    foreach (XmlNode sftp2_node in sftp2_hd)
    {
      foreach (XmlNode sftp2_child_nodes in sftp2_node.ChildNodes)
      {
        Console.WriteLine(sftp2_child_nodes.LocalName);
        Console.WriteLine(sftp2_child_nodes.InnerText);
      }
      
    }
