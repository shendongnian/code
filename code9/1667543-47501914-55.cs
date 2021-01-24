    public DelegateCommand AddGalleryCommand { get; set; }
    public AddGalleryViewModel()
    {
        AddGalleryCommand = new DelegateCommand(AddGallery, CanAddGallery)
        ...
    }
