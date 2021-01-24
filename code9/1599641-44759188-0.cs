    public sealed partial class MainPage : Page 
    {  
        public static MainPage mainPage { get; set; }
    
        public MainPage()
        {
            this.InitializeComponent();
            mainPage = this;       
        }
    }
