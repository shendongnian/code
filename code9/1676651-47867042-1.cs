    public ImageSource WindowIcon
    {
        get { return GetWindowIcon().ToImageSource(); }
    }
    public static Icon GetWindowIcon()
    {
        return Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
    }
