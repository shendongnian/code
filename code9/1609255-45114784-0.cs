        private async void btnDeleteContact_Click(object sender, RoutedEventArgs e)
        {
            StorageFile file = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("Contacts.xml");
            XDocument xdoc = XDocument.Load(file.Path);
            if (lstBox.SelectedIndex != -1)
            {
    var id = lstBox.SelectedItem.ToString();
    XmlNode node = xdoc .SelectSingleNode(string.Format("/Contacts/Contact[@ID='{0}']",id));
    
    if (node != null)
    {
    
       XmlNode parent = node.ParentNode;
       parent.RemoveChild(node);
       updateXMLFile(xdoc);
    }
    
            }
        }
