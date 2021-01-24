    public class MainViewModel : ViewModelBase {
        public MainViewModel(IDataService ds) {
            _dataService = ds;
            this.Initialize += OnInitialize;
            //Un-comment if you want to call event immediately
            //Initialize(this, EventArgs.Empty);
        }
        public event EventHandler Initialize;
        private async void OnInitialize(object sender, EventArgs e) {
            var det = await RemoteFileUtils.GetRemoteFileDetailsAsync("https://example.com/file.txt");
        }
        //Or call this after class has created.
        public void Ready() {
            Initialize(this, EventArgs.Empty);
        }
    }
