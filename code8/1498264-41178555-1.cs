    private async void btnreadsd_Click(object sender, RoutedEventArgs e)
    {
       StorageFolder externalDevices = Windows.Storage.KnownFolders.RemovableDevices;
       // Get the first child folder, which represents the SD card.
       StorageFolder sdCard = (await externalDevices.GetFoldersAsync()).FirstOrDefault();
       if (sdCard != null)
       {
           // An SD card is present and the sdCard variable now contains a reference to it.
           StorageFile txtfile = await sdCard.GetFileAsync("text.txt");          
           string testtext = await FileIO.ReadTextAsync(txtfile);
           txtreadresult.Text = testtext;
       }
       else
       {
           // No SD card is present.
       }
    }
 
