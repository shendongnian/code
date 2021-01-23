    public MainWindow()
            {
                InitializeComponent();
                EventManager.RegisterClassHandler(typeof(Window), Keyboard.KeyUpEvent, new KeyEventHandler(HandleKeyReleased), true);
                EventManager.RegisterClassHandler(typeof(Window), Keyboard.KeyDownEvent, new KeyEventHandler(HandleKeyPressed), true);
            }
    private void HandleKeyReleased(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Space)
                {
                    //stop playing note
                }
            }
    private void HandleKeyPressed(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Space)
                {
                    //play some note
                }
            }
