    private Capture capture;
    private HaarCascade haarCascade;
    // if you are using emgucv 2.X then use HaarCascade and 
    // if you are using emgucv 3.X then use CascadeClassifier
    DispatcherTimer timer;
    public MainWindow()
    {
      InitializeComponent();
    }
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      capture = new Capture();
      haarCascade = new HaarCascade(@"haarcascade_frontalface_alt_tree.xml");
      timer = new DispatcherTimer();
      timer.Tick += new EventHandler(timer_Tick);
      timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
      timer.Start();
    }
