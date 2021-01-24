    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            this.Loaded += Page1_Loaded;
        }
        private bool _isLoaded;
        private void Page1_Loaded(object sender, RoutedEventArgs e)
        {
            if(!_isLoaded)
            {
                //Your code
                _isLoaded = true;
            }
        }
    }
