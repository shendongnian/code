    public UserControl1()
    {
        InitializeComponent();
        this.Loaded += (s, e) =>
        {
            if (this.DataContext == null)
            {
                MainWindow parentWindow = Window.GetWindow(this) as MainWindow;
                if (parentWindow != null)
                {
                    ParentViewModel parentViewModel = parentWindow.DataContext as ParentViewModel;
                    if (parentViewModel != null)
                    {
                        //set One or Two or do whatever you want to do here...
                    }
                }
            }
        };
    }
