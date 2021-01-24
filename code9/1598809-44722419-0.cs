    public partial class MainWindow : Window
        {
    
    
    
            public string MyName
            {
                get { return (string)GetValue(MyNameProperty); }
                set { SetValue(MyNameProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for MyName.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty MyNameProperty =
                DependencyProperty.Register("MyName", typeof(string), typeof(MainWindow), new PropertyMetadata(string.Empty));
    
    
            public MainWindow()
            {
                InitializeComponent();
    
                MyName = "The main window.";
            }
        }
