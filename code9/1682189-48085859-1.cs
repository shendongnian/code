    private async void StartRename_Click(object sender, RoutedEventArgs e)
    {
        var newDir = dir + @"\Renamed";
        Directory.CreateDirectory(newDir);
        vm.ProgBarValue = 0;
        vm.ProgBarBrush = new SolidColorBrush(Colors.Orange);
        await Task.Run(() =>
        {
            foreach (var pic in pics)
            {
                if (File.Exists(newDir + @"\" + pic.newName))
                {
                    MessageBox.Show("File " + newDir + @"\" + pic.newName + " already exists. Skipping remaining files...", "File already exists");
                    return;
                }
                File.Copy(pic.fileInfo.FullName, newDir + @"\" + pic.newName);
                vm.ProgBarValue++;
            }                
        });
        vm.ProgBarBrush = new SolidColorBrush(Colors.Green);
    }
