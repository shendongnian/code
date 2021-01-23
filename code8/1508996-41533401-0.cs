        private async void ButtonClean_Click(object sender, RoutedEventArgs e)
        {
            matchPattern = textBoxPattern.Text;
            buttonOpen.IsEnabled = false;
            buttonClean.IsEnabled = false;
            await Task.Run(() => CleanFolder(folderPath));
            textBoxList.Text += "Mission complete!";
            buttonOpen.IsEnabled = true;
        }
        private void CleanFolder(string path)
        {
            var filePaths = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
            foreach (var filePath in filePaths)
            {
                var matchResult = Regex.Match(filePath, matchPattern);
                if (matchResult.Success)
                {
                    File.Delete(filePath);
                    System.Windows.Application.Current.Dispatcher.Invoke(delegate
                    {
                        // this working fast
                        textBoxList.Text  = "File deleted: " + filePath + "\n";
                        // this working slow and slower over time
                      //textBoxList.Text += "File deleted: " + filePath + "\n";
                        textBoxList.ScrollToEnd();
                    });
                }
            }
        }
