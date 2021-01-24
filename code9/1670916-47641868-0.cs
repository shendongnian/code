    XmlDocument doc = new XmlDocument();
    doc.Load("C:\\Users\\Dylan\\Desktop\\people.xml");
    string name = textBox1.Text;
    bool correct = false;
    foreach (XmlNode node in doc.SelectNodes("//Person"))
    {
        string Name = node.SelectSingleNode("Name").InnerText;
        if (Name == name)
        {
            // Using the Person node, select the Age node
            XmlNode ageNode = node.SelectSingleNode("Age");
            // Update the value with whatever new value is required
            ageNode.InnerText = "10";
        }
       
        if (correct == true) break;
    }
    // Remember to save the changes!
    doc.Save("C:\\Users\\Dylan\\Desktop\\people.xml");
