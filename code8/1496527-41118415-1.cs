    public sealed partial class MainPage : Page
        {
            private Key _lastKeyPressed;
            public MainPage()
            {
                this.InitializeComponent();
            }
    
            protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            }
    
            protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
            {
                Window.Current.CoreWindow.KeyDown -= CoreWindow_KeyDown;
            }
    
            private void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs args)
            {
                if(e.Key != _lastKeyPressed)
                {
                    //do something
                    Debug.WriteLine($"CoreWindow_KeyDown: {args.VirtualKey}  {args.KeyStatus.WasKeyDown} {DateTime.Now:mm:ss.ss}");
                }
                _lastKeyPressed = e.Key;
            }
        }
