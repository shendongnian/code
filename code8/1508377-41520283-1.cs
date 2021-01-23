    public OnScreenKeyboard()
    {
        this.InitializeComponent();
        //remove the old resource
        MainGrid.Resources.Remove("EngRus");
        //create a new BitmapImage
        System.Windows.Media.Imaging.BitmapImage image = new System.Windows.Media.Imaging.BitmapImage(new System.Uri("/TermControls;component/Images/shift.png", System.UriKind.RelativeOrAbsolute));
        MainGrid.Resources.Add("EngRus", image);
    }
