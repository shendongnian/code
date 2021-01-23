    private ObservableCollection<DirectoryInfo> inputDirectories = new ObservableCollection<DirectoryInfo>();
    
    inputDirectories.Add(new DirectoryInfo(@"C:\Documents"));
    
    public IEnumerable<string> Files => inputDirectories.SelectMany(d => GetFilesInDirectory(d));
    private IEnumerable<string> GetFilesInDirectory(DirectoryInfo directory)
      {
         return directory.GetFiles().Select(x => x.FullName);
      }
