    public MainWindow()
    {
        InitializeComponent();
        Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("pack://application:,,,/WpfControlLibrary1;component/ResourceDictionaryWithDataTemplate.xaml")});
        theContentControl.Content = new WpfControlLibrary1.A()
    }
