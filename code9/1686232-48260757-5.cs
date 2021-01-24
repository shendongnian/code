    public MainWindow()
    {
        InitializeComponent();
        DataContext = MyClass;
    }
    myClass MyClass = new myClass();
    private void button_Click(object sender, RoutedEventArgs e)
    {
        if(MyClass.IsChecked)
            MyClass.IsChecked = false;
        else
            MyClass.IsChecked = true;
    }
    
