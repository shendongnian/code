    private async void updateXMLFile(XDocument xdoc)
            {
                try
                {
                    //StorageFile file = await installedLocation.CreateFileAsync("Contacts.xml", CreationCollisionOption.ReplaceExisting);
                    StorageFile file = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("Contacts.xml"); //This line was the replacement for the one above.
                    await FileIO.WriteTextAsync(file, xdoc.ToString());
                }
                catch (Exception ex)
                {
                    String s = ex.ToString();
                }
            }
 
