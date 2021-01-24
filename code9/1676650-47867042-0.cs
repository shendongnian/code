    public ImageSource WindowIcon
    {
        get { return GetWindowIcon().ToImageSource(); }
    }
    public Icon GetWindowIcon()
    {
        return Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
    }
