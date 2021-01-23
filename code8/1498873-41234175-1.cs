        Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        async void WriteFile()
        {
            StorageFile sampleFile = await localFolder.CreateFileAsync("test.txt",
                CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(sampleFile, "111");
        }
        async void ReadFile()
        {
            try
            {
                StorageFile sampleFile = await localFolder.GetFileAsync("test.txt");
                String content = await FileIO.ReadTextAsync(sampleFile);
            }
            catch (Exception)
            {
                // Timestamp not found
            }
        }
