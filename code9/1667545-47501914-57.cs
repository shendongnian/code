	public DelegateCommand<Gallery> AddGalleryCommand { get; set; }
    public AddGalleryViewModel()
    {
        AddGalleryCommand = new DelegateCommand<Gallery>(AddGallery, CanAddGallery)
    }
    private void AddGallery(Gallery gallery)
    {
        ...
    }
	
	private bool CanAddGallery(Gallery gallery)
    {
        ...
    }
	
