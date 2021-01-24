        ObservableCollection<GalleryImage> _images = new ObservableCollection<GalleryImage>();
        
        public ObservableCollection<GalleryImage> ImagesZoom{get => _images;}
        public PageViewModel(ObservableCollection<GalleryImage> _images)
        {
            this._images = _images;
        }
    
