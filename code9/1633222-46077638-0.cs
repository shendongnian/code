        private InputInjector _inputInjector;
        private InjectedInputMouseInfo _mouse;
        private Vector2 _positionDelta;
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            _inputInjector = InputInjector.TryCreate();
            _inputInjector.InitializeTouchInjection(InjectedInputVisualizationMode.Indirect);
            RunMouse();
        }
        private async void RunMouse()
        {
            _positionDelta = Vector2.One;
            for (int i = 0; i < 500; i++)
            {
                await Task.Delay(10);
                if (i == 100) PointDown();
                else if (i == 400) PointUp();
                else PointMove();
                _inputInjector.InjectMouseInput(new List<InjectedInputMouseInfo>{ _mouse });
            }
        }
        private void PointDown()
        {
            _mouse = new InjectedInputMouseInfo
            {
                DeltaX = (int)_positionDelta.X,
                DeltaY = (int)_positionDelta.Y,
                MouseOptions = InjectedInputMouseOptions.LeftDown,
            };
        }
        private void PointUp()
        {
            _mouse = new InjectedInputMouseInfo
            {
                DeltaX = (int)_positionDelta.X,
                DeltaY = (int)_positionDelta.Y,
                MouseOptions = InjectedInputMouseOptions.LeftUp,
            };
        }
        private void PointMove()
        {
            _mouse = new InjectedInputMouseInfo
            {
                DeltaX = (int)_positionDelta.X,
                DeltaY = (int)_positionDelta.Y,
                MouseOptions = InjectedInputMouseOptions.Move,
            };
        }
