    public class EntryViewModel : ViewModelBase
    {
        private string _FileSize;
        public string FileSize
        {
            get
            {
                return _FileSize;
            }
            set
            {
                _FileSize = value;
                OnPropertyChanged();
            }
        }
    }
