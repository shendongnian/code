	public InternalDelegateCommand CreateGalleryCommand { get; set; }
    public CreateGalleryViewModel()
    {
        CreateGalleryCommand = new InternalDelegateCommand(CreateGallery)
    }
    private void CreateGallery()
    {
        Gallery gallery = new Gallery();
		
		...
    }
