    public MainWindow()
    {
        InitializeComponent();
        textBox.DataContext = Log.Instance;
        Debug.WriteLine($"Text [ctor before change]: {textBox.Text}");
        // Output:
        Log.Instance.logContent += "aaa" + Environment.NewLine; //this working
        Debug.WriteLine($"Text [ctor after change]: {textBox.Text}");
        // Output:
    }
    private void button_Click(object sender, RoutedEventArgs e)
    {
        Test.Instance.Volaj();
    }
    private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        Debug.WriteLine($"Text [Loaded before change]: {textBox.Text}");
        // Output: aaa
        Log.Instance.logContent += "bbb" + Environment.NewLine;
        Debug.WriteLine($"Text [Loaded after change]: {textBox.Text}");
        // Output: aaa
    }
