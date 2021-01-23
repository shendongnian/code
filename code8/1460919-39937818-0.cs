    private async void ButtonDemo_Click(object sender, RoutedEventArgs e)
    {
         // Get our local storage folder
         var localFolder = ApplicationData.Current.LocalFolder;
                 
         XmlDocument xmlDocument;
                 
         // Try to get file 
         var file = await localFolder.TryGetItemAsync("MyData.xml") as IStorageFile;
                 
         if(file != null)
         {
              // File exists -> Load into XML document
              xmlDocument = await XmlDocument.LoadFromFileAsync(file);
         }
         else
         {
              // File does not exist, create new document in memory
              xmlDocument = new XmlDocument();
              xmlDocument.LoadXml(@"<?xml version=""1.0"" encoding=""UTF-8""?>" + Environment.NewLine + "<root></root>");
         }
    
         // Now show the current contents
         TextBoxLog.Text = "";
    
         var lEntries = xmlDocument.GetElementsByTagName("Entry");
         foreach(var lEntry in lEntries)
         {
              TextBoxLog.Text += lEntry.InnerText + Environment.NewLine;
         }
    
         // Now add a new entry
         var node = xmlDocument.CreateElement("Entry");
         node.InnerText = DateTime.Now.ToString();
         xmlDocument.DocumentElement.AppendChild(node);
    
         // If the file does not exist yet, create it
         if(file == null)
         {
              file = await localFolder.CreateFileAsync("MyData.xml");
         }
    
         // Now save the document
         await xmlDocument.SaveToFileAsync(file);
    
    }
