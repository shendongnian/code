    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Files = GenerateFiles();
        }
        private ObservableCollection<MyModel> GenerateFiles()
        {
            var items = new ObservableCollection<MyModel>();
            for (int i = 0; i < 30; i++)
            {
                items.Add(new MyModel
                {
                    ThumbnailImage = "ms-appx:///Images/WindowsLogo.png",
                    File = new File
                    {
                        DisplayName = $"File {i}"
                    }
                });
            }
            return items;
        }
        public ObservableCollection<MyModel> Files { get; set; }
    }
    public class MyModel
    {
        public string ThumbnailImage { get; set; }
        public File File { get; set; }
    }
    public class File
    {
        public string DisplayName { get; set; }
    }
