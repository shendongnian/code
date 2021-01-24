    public class MasterPageItem : INotifyPropertyChanged
    {
        private string _title;
        private string _iconSource;
        private bool _isActive;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        /// <summary>
        /// Set or return icon file
        /// If IsActive == true
        /// will add suffix "_active" to return value,
        /// 
        /// Note:
        /// Icons file should be the pair"
        ///  - icon_name.png
        ///  - icon_name_active.png
        /// 
        /// </summary>
		public string IconSource
        {
            get
            {
                if (!IsActive)
                    return _iconSource;
                return Path.GetFileNameWithoutExtension(_iconSource) + "_active" + Path.GetExtension(_iconSource);
            }
            set
            {
                _iconSource = value;
                OnPropertyChanged(nameof(IconSource));
            }
        }
        /// <summary>
        /// Is menu item is selected
        /// </summary>
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                OnPropertyChanged());
            }
        }
		public Type TargetType { get; set; }
        // Important for data-binding
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
