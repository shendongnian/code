    private void Search_Click(object sender, RoutedEventArgs e)
    {
        var path = Constants.allMoviesPath;
    
        var ext = new List<string> { @".txt", @".ini", @".exe", @".mob", @".srt", @".ass" };
    
        lstBox.ItemsSource = Directory.GetFiles(path, "*" + SearchString + "*", SearchOption.AllDirectories)
                    .Where(f => !ext.Contains(System.IO.Path.GetExtension(f)))
                   .Select(f => System.IO.Path.GetFileNameWithoutExtension(f))
                   .ToList();
    
        //  Null when it should be null
        lstBox.DisplayMemberPath = null;
    }
    
    private void btnStats_Click(object sender, RoutedEventArgs e)
    {
        lstBox.ItemsSource = FileLists.MoviesCountSizeStats();
    
        //  "Name" when it should be "Name"
        lstBox.DisplayMemberPath = "Name";
    }
