    private WriteableBitmap _selectedImageSource;
    public WriteableBitmap SelectedImageSource
    {
        get { return _selectedImageSource; }
        set
        {
            _selectedImageSource = value;
            OnPropertyChanged(nameof(SelectedImageSource));
        }
    }
