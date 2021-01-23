    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            IntPtr windowHandle = new WindowInteropHelper(this).Handle;
            Dispatcher.Invoke(() =>
            {
                var element = AutomationElement.FromHandle(windowHandle);
                Automation.AddAutomationEventHandler(InvokePattern.InvokedEvent, element, TreeScope.Descendants,
                    (s, a) =>
                    {
                        var src = s as AutomationElement;
                        Debug.WriteLine($"Invoked:{a.EventId.Id},{a.EventId.ProgrammaticName},{src.NativeElement.CurrentName}");
                    });
            });
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Clicked!");
        }
    }
