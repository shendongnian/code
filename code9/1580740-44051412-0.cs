    public class MainViewModel : ViewModelBase {
        public MainViewModel(IDataService ds) {
            _dataService = ds;
            this.Initialize += OnInitialize;
        }
        public event EventHandler Initialize;
        private async void OnInitialize(object sender, EventArgs e) {
            var det = await RemoteFileUtils.GetRemoteFileDetailsAsync("https://example.com/file.txt");
        }
    }
