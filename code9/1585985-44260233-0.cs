    public class MainViewModel : INotifyPropertyChanged
    {
        public string Path
        {
            get { return _path; }
            set
            {
                if (_path != value)
                {
                    _path = value;
                    OnPropertyChanged(nameof(Path));
                    AsyncProperty = new NotifyTaskCompletion<int>(YourAsyncMethod());
                }
            }
        }
        public NotifyTaskCompletion<string> AsyncProperty { get; private set; }
    }
----------
    <Label Content="{Binding AsyncProperty.Result}"/>
