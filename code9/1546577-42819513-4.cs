    public sealed partial class PartCreatePage : Page
    {
    
        private UserOperation operation { get; set; }
    
        public  PartCreatePage()
        {
            this.InitializeComponent();
            DataContext = new UserOperation();
        }
