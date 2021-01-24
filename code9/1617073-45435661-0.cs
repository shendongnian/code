    XmlElement childElement = doc.CreateElement("City"); // Creation of <City> ....... <City>
    childElement.InnerText = "Hyderabad";// Adding Value <City> Hyderabad </City>
     
    XmlNode SelectNode = doc.SelectSingleNode("Group/user"); //where to add XPATH expression 
    SelectNode.InsertAfter(childElement, SelectNode.LastChild);//selects 1st "user" node lastchild and insert after
    childElement = doc.CreateElement("City"); // Creation of <City> ....... <City>
    childElement.InnerText = "Hyderabad";// Adding Value <City> Hyderabad </City>
    XmlNode refNode = doc.SelectSingleNode("Group/user[4]");// Indicating 4 Node in XML file
    refNode.InsertAfter(childElement, refNode.LastChild); //selects 4th  "user" node lastchild and insert after
