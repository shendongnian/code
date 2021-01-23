    public void MyMethod(XmlNode node)
    {
          var newElement = node.OwnerDocument.CreateElement("element");
          node.AppendChild(newElement);
    }
