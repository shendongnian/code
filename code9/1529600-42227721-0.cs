    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.Load("c:\\yourxml.xml");
    XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Properties");
    string actionLogPrompt= "", answer= "", subQBackColour="";
    foreach (XmlNode node in nodeList)
    {
    actionLogPrompt = node.SelectSingleNode("ActionLogPrompt").InnerText;
    answer = node.SelectSingleNode("Answer").InnerText;
    subQBackColour= node.SelectSingleNode("SubQBackColour").InnerText;
    MessageBox.Show(actionLogPrompt+ " " + answer+ " " + subQBackColour);
    }
