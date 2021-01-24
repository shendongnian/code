    public partial class MainWindow : Window
    {
        UserControl _currentRoom;  
        public MainWindow()
        {
            InitializeComponent();
        }
        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
             this.areaContainer.Children.Clear();
             _currentRoom = null;
            if (e.LeftButton == MouseButtonState.Pressed)
                _currentRoom = new Room1(); 
            if(e.RightButton == MouseButtonState.Pressed) 
                _currentRoom = new Room2(); 
            this.areaContainer.Children.Add(_currentRoom); 
            base.OnPreviewMouseDown(e);
        }
    }
