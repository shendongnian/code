    public partial class MainView : Window
    {
        public MainView()
        {
            this.InitializeComponent();
            this.DataContext = new MainViewModel(/*pass your dialog here*/);
        }
    }
