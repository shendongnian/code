     ObservableCollection<GalleryImage> _images = new ObservableCollection<GalleryImage>();
    
    _images .Add(new GalleryImage("jsna", 123.1, "13sd"));
    
    PageViewModel = new PageViewModel(_images);
