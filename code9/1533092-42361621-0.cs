       string globalListName = "Test Global List";
           
       XmlElement returnElement;
       XmlDocument root = new XmlDocument();
         
       //Create a package element
        XmlElement newChild = root.CreateElement("Package");
        root.AppendChild(newChild);
         
       //Create a Destroy Global List element
      XmlElement element2 = root.CreateElement("DestroyGlobalList");
      element2.SetAttribute("ListName", "*" + globalListName);
      element2.SetAttribute("ForceDelete", true.ToString(CultureInfo.InvariantCulture));
      newChild.AppendChild(element2);
       
      //Send Update to Work Item Store
      store.SendUpdatePackage(newChild, out returnElement, false);
