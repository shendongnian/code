    public partial class Child : Window
    {
        // define event
        public event EventHandler MyEvent;
        protected void OnMyEvent()
        {
            if (this.MyEvent != null)
                this.MyEvent(this, EventArgs.Empty);
        }
        public Child()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Child_Loaded);
        }
        void Child_Loaded(object sender, RoutedEventArgs e)
        {
            // call event
            this.OnMyEvent();
        }
    }
