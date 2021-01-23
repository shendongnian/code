    private void btnAdd_Click(object sender, RoutedEventArgs e)
    {
        Task.Run(() =>
        {
            string[] listOfFiles = Directory.GetFiles(@"C:\TEST\", "*.*", SearchOption.AllDirectories);
            int count = 0;
            foreach (var file in listOfFiles)
            {
                if (file.Contains("CLIENT"))
                {
                    count++;
                    FilesFound f = new FilesFound();
                    f.FileName = file;
                    f.FileCount = count.ToString();
                    Dispatcher.BeginInvoke(new Action(() => this.file.Add(f)));
                    Thread.Sleep(500);
                }
            }
        });
    }
