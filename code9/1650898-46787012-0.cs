    async void AccessTheWebAsync()
        {
            //Maybe you want to do this inside a try catch and verify that at least 1 device is connected before you go on....
            var folderList = await KnownFolders.RemovableDevices.GetFoldersAsync();
            foreach (var device in await KnownFolders.RemovableDevices.GetFoldersAsync())
            {
                try
                {
                    StorageFolder remd = await device.GetFolderAsync("ad_runner");
                    IReadOnlyList<StorageFile> fileList = await remd.GetFilesAsync();
                    foreach (StorageFile file in fileList)
                    {
                        //Your logic here....
                       dir_lbl.Text = dir_lbl.Text + "\r\n" + file.Name;
                    }
                }
                catch (Exception)
                {
                    
                }
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    rightGridWrapper.Children.Add(new TextBlock { Text = $"DeviceName: {device.Name}" });
                });
            }
    }
