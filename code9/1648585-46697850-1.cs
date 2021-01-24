    private BitmapImage _listIcon;
    public BitmapImage ListIcon
    {
        get
        {
            if (_listIcon == null)
            {
                _listIcon = ProvideListIcon();
            }
            return _listIcon;
        }
    }
    protected override BitmapImage ProvideListIcon()
    {
        BitmapImage img = new BitmapImage(new Uri("pack://application:,,,/[Project];Component/Images/TestImage.png", UriKind.RelativeOrAbsolute));
        if (img.CanFreeze)
        {
            img.Freeze();
        }
        return img;
    }
