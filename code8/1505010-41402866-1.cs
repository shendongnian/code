        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string[] listOfFiles = Directory.GetFiles(@"C:\TEST\", "*.*", SearchOption.AllDirectories);
            await Task.Run(() =>
                {
                    int count = 0;
                    foreach (var file in listOfFiles)
                    {
                        if (file.Contains("CLIENT"))
                        {
                            count++;
                            FilesFound f = new FilesFound();
                            f.FileName = file;
                            f.FileCount = count.ToString();
                            this.file.Add(f);
                            Thread.Sleep(500);
                        }
                    }
                });
        }
