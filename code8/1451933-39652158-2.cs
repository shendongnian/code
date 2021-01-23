    try
            {
                await ApplicationData.Current.LocalFolder.GetItemAsync("Scedule.db");
            }
            catch (System.IO.FileNotFoundException)
            {
                StorageFile databaseFile =
                        await Package.Current.InstalledLocation.GetFileAsync($"Assets\\{"Scedule.db"}");
                await databaseFile.CopyAsync(ApplicationData.Current.LocalFolder);
            }
