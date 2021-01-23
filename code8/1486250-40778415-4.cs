    StringBuilder nodeText = new StringBuilder();
    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.LoadXml(<your xml here>);
    foreach (XmlNode lognode in xmlDoc.SelectNodes("/TestLogDataSet/Log[Message]")) //select all log nodes with Message as child tag
    {
        string status = lognode.SelectSingleNode("./Status").InnerText;
        foreach (XmlNode node in lognode.ChildNodes)
        {
             if (node.LocalName == "Message" && !string.Equals(status,"failed",StringComparison.OrdinalIgnoreCase))
             {
                  continue;
             }
             nodeText.Append(node.LocalName);
             nodeText.Append(":");
             nodeText.Append(node.InnerText);//read inner text of node here
             nodeText.Append("\n");
        }
    }
    Console.WriteLine(nodeText.ToString());
