    private ImageSource _myImageSource;
    public ImageSource MyImageSource {
        get { return _myImageSource; }
        set {
            if (value != _myImageSource)
            {
                _myImageSource = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MyImageSource)));
            }
        }
    }
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = this;
        System.Drawing.Icon ExtractedIcon = System.Drawing.Icon.ExtractAssociatedIcon(FilePath);
        MyImageSource = Imaging.CreateBitmapSourceFromHIcon(ExtractedIcon.Handle, new Int32Rect(0, 0, 32, 32), BitmapSizeOptions.FromEmptyOptions());
        ExtractedIcon.Dispose();
        this.Icon       = MyImageSource;  //This is Working
    }
