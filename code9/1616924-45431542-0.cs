    public MainWindow()
    {
        Stuff = new MediaElement
        {
            Source = new Uri("MovingImages_2017-03-10-05-02-22.wmv", UriKind.Relative),
            LoadedBehavior = MediaState.Play
        };
        InitializeComponent();
    }
