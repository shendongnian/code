        using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Threading;
    using SharpDX.XInput;
    
    namespace ElBruno.GameController
    {
        public partial class MainWindow : INotifyPropertyChanged
        {
            DispatcherTimer _timer = new DispatcherTimer();
            private string _leftAxis;
            private string _rightAxis;
            private string _buttons;
            private Controller _controller;
        public MainWindow()
        {
            DataContext = this;
            Loaded += MainWindow_Loaded;
            Closing += MainWindow_Closing;
            InitializeComponent();
            _timer = new DispatcherTimer {Interval = TimeSpan.FromMilliseconds(100)};
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }
        void _timer_Tick(object sender, EventArgs e)
        {
            DisplayControllerInformation();
        }
        void DisplayControllerInformation()
        {
            var state = _controller.GetState();
            LeftAxis = string.Format("X: {0} Y: {1}", state.Gamepad.LeftThumbX, state.Gamepad.LeftThumbY);
            RightAxis = string.Format("X: {0} Y: {1}", state.Gamepad.RightThumbX, state.Gamepad.RightThumbX);
            //Buttons = string.Format("A: {0} B: {1} X: {2} Y: {3}", state.Gamepad.Buttons.ToString(), state.Gamepad.LeftThumbY);
            Buttons = string.Format("{0}", state.Gamepad.Buttons);
        }
        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            _controller = null;
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _controller = new Controller(UserIndex.One);
            if (_controller.IsConnected) return;
            MessageBox.Show("Game Controller is not connected ... you know ;)");
            App.Current.Shutdown();
        }
        #region Properties
        public string LeftAxis
        {
            get
            {
                return _leftAxis;
            }
            set
            {
                if (value == _leftAxis) return;
                _leftAxis = value;
                OnPropertyChanged();
            }
        }
        public string RightAxis
        {
            get
            {
                return _rightAxis;
            }
            set
            {
                if (value == _rightAxis) return;
                _rightAxis = value;
                OnPropertyChanged();
            }
        }
        public string Buttons
        {
            get
            {
                return _buttons;
            }
            set
            {
                if (value == _buttons) return;
                _buttons = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
