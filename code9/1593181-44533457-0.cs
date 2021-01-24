    class TreeItemViewModel : NotifyPropertyChangedBase
    {
        public ObservableCollection<TreeItemViewModel> Items { get; }
            = new ObservableCollection<TreeItemViewModel>();
        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { _UpdateField(ref _isSelected, value, _OnBoolPropertyChanged); }
        }
        private bool _isExpanded;
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set { _UpdateField(ref _isExpanded, value, _OnBoolPropertyChanged); }
        }
        private void _OnBoolPropertyChanged(bool obj)
        {
            _RaisePropertyChanged(nameof(FullText));
        }
        private string _text;
        public string Text
        {
            get { return _text; }
            set { _UpdateField(ref _text, value, _OnTextChanged); }
        }
        private void _OnTextChanged(string obj)
        {
            _RaisePropertyChanged(nameof(FullText));
        }
        public string FullText
        {
            get { return $"{Text} (IsSelected: {IsSelected}, IsExpanded: {IsExpanded})"; }
        }
    }
