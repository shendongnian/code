            private async void ListA_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            //f.MessageBox(e.Items.First().GetType().ToString());
            try
            {
                List<IStorageItem> files = new List<IStorageItem>();
                StorageFile file = e.Items.First() as StorageFile;
                files.Add(file);
                e.Data.SetStorageItems(files);
                //e.Data.SetData(StandardDataFormats.Text, e.Items.);
                
            }catch(Exception ex)
            {
                f.MessageBox(ex.Message);
            }
            
        }
        private async void ListC_DragEnter(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
            //IReadOnlyList<IStorageItem> files = await e.DataView.GetStorageItemsAsync();
           
        }
        private async void ListC_Drop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.DataView.Contains(StandardDataFormats.StorageItems))
                {
  
                    var items = await e.DataView.GetStorageItemsAsync();
                    if (items.Count > 0)
                    {
                        var storageFile = items[0] as StorageFile;
                        ListC.Items.Add(storageFile.Name);
                    }
                }
            }catch
            {
                f.MessageBox("nope");
            }
