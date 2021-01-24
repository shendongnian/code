    class VideoListModel : ViewModelBase
    {
        private IKnownFolderReader _knownFolder;
        private ObservableCollection<VideoListItem> _videoItems;
        public ObservableCollection<VideoListItem> VideoItems
        {
            get { return _videoItems; }
            set { Set(ref _videoItems, value); RaisePropertyChanged(); }
        }
       
        private VideoListItem _selectedVideoItem;
        public VideoListItem SelectedVideoItem
        {
            get { return _selectedVideoItem; }
            set { Set(ref _selectedVideoItem, value);}
        }
        public VideoListModel(IKnownFolderReader knownFolder)
        {
            _knownFolder = knownFolder;
            var task = _knownFolder.GetData();
            task.ConfigureAwait(true).GetAwaiter().OnCompleted(() => {
                List<VideoListItem> items = task.Result;
                VideoItems = new ObservableCollection<VideoListItem>(items);
            });
        }
       
    }
