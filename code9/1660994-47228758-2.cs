     private async void btnOpen_Click(object sender, RoutedEventArgs e)
            {
                var folder = await StorageApplicationPermissions.FutureAccessList.GetFolderAsync(token);
                var file = await folder.GetFileAsync("abc.txt");
                var text = await FileIO.ReadTextAsync(file);
                Debug.WriteLine(text);
                await Launcher.LaunchFolderAsync(folder);
            }
