    private List<string> kepek = new List<string>();
    private int képnévIndex = 0;
    private DispatcherTimer timer;
    
    //this is my stand-in for your constructor. you didn't put it in the example, so i'm using "myClass"
    public myClass()
    {
        // you will still need InitializeComponent();
        InitializeComponent();
        LoadImages();
        setupTimer(10);
        displayCurrentDate();
    }
    private void setupTimer(int timeoutInSeconds)
    {
        if(timer != null)
        {
            timer.Stop();
        }
        timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(timeoutInSeconds) };
        timer.Tick += (sender, args) =>
        {
             showNextPicture();
        };
    
        timer.Start();
    }
    private void LoadImages()
    {
        string path = @"C:\Teszt\";            
        string[] Files = Directory.GetFiles(path, "*.jpg");
    
        foreach (var item in Files)
        {
            kepek.Add(item);
        }
    }
    
    private void displayCurrentDate()
    {
        string év = "";
        év += DateTime.Now.Year;
        string hónap = "";
        hónap += DateTime.Now.Month;
        string nap = "";
        nap += DateTime.Now.Day;              
        Date.Content = év + "." + hónap + "." + nap + ".";
    }
    
    private void showNextPicture()
    {
        string képnév = kepek[képnévIndex];
        image.Source = new BitmapImage(new Uri(képnév));
        képnévIndex++;
        if (képnévIndex == kepek.Count)
            képnévIndex = 0;
    }
    private void Szövegdoboz_TextChanged(object sender, TextChangedEventArgs e)
    {
        int parsedNumberOfSeconds;
        //if we entered something that can not be parsed to a number, exit.
        if(!int.tryParse(Szövegdoboz.Text, out parsedNumberOfSeconds))
            return;
        setupTimer(parsedNumberOfSeconds);
    }
