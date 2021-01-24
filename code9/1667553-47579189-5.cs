    class GalleryViewModel : ObservableObject
    {
        private ObservableCollection<Gallery> _galleryList;
        public ObservableCollection<Gallery> GalleryList
        {
            get { return _galleryList; }
            set
            {
                _galleryList = value;
                NotifyPropertyChanged();
            }
        }
        private Gallery _galleryToAdd;
        public Gallery GalleryToAdd
        {
            get { return _galleryToAdd; }
            set
            {
                if (_galleryToAdd != value)
                {
                    _galleryToAdd = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public DelegateCommand<Gallery> AddGalleryCommand { get; set; }
        public GalleryViewModel()
        {
            GalleryList = new ObservableCollection<Gallery>();
            AddGalleryCommand = new DelegateCommand<Gallery>(AddGallery, CanAddGallery);
            GalleryToAdd = new Gallery();
            GalleryToAdd.PropertyChanged += GalleryToAdd_PropertyChanged;
        }
        private void AddGallery(object parameter)
        {
            Gallery gallery = (Gallery)parameter;
            Gallery g = new Gallery();
            g.Name = gallery.Name;
            g.Path = gallery.Path;
            GalleryList.Add(g);
        }
        private bool CanAddGallery(object parameter)
        {
            Gallery gallery = (Gallery)parameter;
            if (string.IsNullOrEmpty(gallery.Name) || string.IsNullOrEmpty(gallery.Path))
            {
                return false;
            }
            return true;
        }
        private void GalleryToAdd_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Name" || e.PropertyName == "Path")
            {
                AddGalleryCommand.RaiseCanExecuteChanged();
            }
        }
    }
