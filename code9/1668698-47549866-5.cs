    //Code-Behind of your Window
    public class YourWindow : Window
    {
        public YourWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
        }
    }
