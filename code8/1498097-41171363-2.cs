    private ImageSource image;
    public ImageSource Image
    {
        get { return image; }
        set
        {
            image = value;
            NotifyPropertyChanged("Image");
        }
    }
