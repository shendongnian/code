    public sealed partial class ProgressWindowControl : Window
    {
        public static readonly DependencyProperty ProgressProperty =
         DependencyProperty.Register("Progress", typeof(double), typeof(ProgressWindowControl), new PropertyMetadata(0d));
        public static readonly DependencyProperty MaxProgressProperty =
         DependencyProperty.Register("MaxProgress", typeof(double), typeof(ProgressWindowControl), new PropertyMetadata(100d));
        public static readonly DependencyProperty IsIndeterminateProperty =
            DependencyProperty.Register("IsIndeterminate", typeof(bool), typeof(ProgressWindowControl), new PropertyMetadata(true));
        public static readonly DependencyProperty StateProperty =
        DependencyProperty.Register("State", typeof(string), typeof(ProgressWindowControl), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty IsCancelAllowedProperty =
         DependencyProperty.Register("IsCancelAllowed", typeof(bool), typeof(ProgressWindowControl), new PropertyMetadata(false));
        private ProgressWindowControl()
        {
            InitializeComponent();
        }
        public double Progress
        {
            get
            {
                return (double)GetValue(ProgressProperty);
            }
            set
            {
                SetValue(ProgressProperty, value);
            }
        }
        public double MaxProgress
        {
            get
            {
                return (double)GetValue(MaxProgressProperty);
            }
            set
            {
                SetValue(MaxProgressProperty, value);
            }
        }
        public bool IsIndeterminate
        {
            get
            {
                return (bool)GetValue(IsIndeterminateProperty);
            }
            set
            {
                SetValue(IsIndeterminateProperty, value);
            }
        }
        public string State
        {
            get
            {
                return (string)GetValue(StateProperty);
            }
            set
            {
                SetValue(StateProperty, value);
            }
        }
        public Action OnProgressWindowCancel { get; set; }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (OnProgressWindowCancel != null)
            {
                uxCancelBtn.IsEnabled = false;
                uxCancelBtn.Content = Strings.Cancelling;
                OnProgressWindowCancel();
            }
        }
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);
        private const int GWL_HWNDPARENT = -8;
        private static ProgressWindowControl _progressWindowControl;
        private static bool _isVisible;
        private static Window _owner;
        private static ResizeMode? _ownerResizeMode;
        private static bool _ownerIsHitTestVisible;
        private static bool _ownerFocusable;
        public static void ShowProgressWindow(Window owner = null)
        {
            if (!_isVisible)
            {
                IntPtr ownerHandle = IntPtr.Zero;
                if (owner != null)
                {
                    _owner = owner;
                    ownerHandle = GetHandler(_owner);
                    //Block owner window input while the progress bar is opened
                    _ownerResizeMode = _owner.ResizeMode;
                    _ownerIsHitTestVisible = _owner.IsHitTestVisible;
                    _ownerFocusable = _owner.Focusable;
                    _owner.ResizeMode = ResizeMode.NoResize;
                    _owner.IsHitTestVisible = false;
                    _owner.Focusable = false;
                    _owner.PreviewKeyDown += Owner_PreviewKeyDown;
                    _owner.PreviewMouseDown += Owner_PreviewMouseDown;
                    _owner.Closing += Owner_Closing;
                }
                //Run window in its own thread
                Thread thread = new Thread(new ThreadStart(() =>
                {
                    SynchronizationContext.SetSynchronizationContext(new DispatcherSynchronizationContext(Dispatcher.CurrentDispatcher));
                    _progressWindowControl = new ProgressWindowControl();
                    // Shutdown the dispatcher when the window closes
                    _progressWindowControl.Closed += (s, e) =>
                        Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);
                    // When the progress window has loaded, if an owner has been specified, attach it to the window, otherwise set Topmost = true
                    ProgressWindowControl._progressWindowControl.Loaded += (s, e) =>
                    {
                        if (owner != null)
                        {
                            IntPtr ownedWindowHandle = GetHandler(_progressWindowControl);
                            SetOwnerWindowMultithread(ownedWindowHandle, ownerHandle);
                        }
                        else
                        {
                            _progressWindowControl.Topmost = true;
                        }
                    };
                    _progressWindowControl.Show();
                    _isVisible = true;
                    System.Windows.Threading.Dispatcher.Run();
                }));
                thread.SetApartmentState(ApartmentState.STA);
                thread.IsBackground = true;
                thread.Start();
            }
        }
        private static void Owner_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }
        private static void Owner_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            e.Handled = true;
        }
        private static void Owner_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            e.Handled = true;
        }
        private static void SetOwnerWindowMultithread(IntPtr windowHandleOwned, IntPtr intPtrOwner)
        {
            if (windowHandleOwned != IntPtr.Zero && intPtrOwner != IntPtr.Zero)
            {
                SetWindowLong(windowHandleOwned, GWL_HWNDPARENT, intPtrOwner.ToInt32());
            }
        }
        private static IntPtr GetHandler(Window window)
        {
            var interop = new WindowInteropHelper(window);
            return interop.Handle;
        }
        public static void CloseProgressWindow()
        {
            if (_progressWindowControl != null && _isVisible)
            {
                if (_progressWindowControl.Dispatcher.CheckAccess())
                {
                    _progressWindowControl.Close();
                }
                else
                {
                    _progressWindowControl.Dispatcher.Invoke(DispatcherPriority.Normal,
                        new ThreadStart(_progressWindowControl.Close));
                }
                if (_owner != null)
                {
                    //Unblock owner input
                    _owner.ResizeMode = _ownerResizeMode ?? ResizeMode.CanResize;
                    _owner.IsHitTestVisible = _ownerIsHitTestVisible;
                    _owner.Focusable = _ownerFocusable;
                    _owner.PreviewKeyDown -= Owner_PreviewKeyDown;
                    _owner.PreviewMouseDown -= Owner_PreviewMouseDown;
                    _owner.Closing -= Owner_Closing;
                }
                //Reset fields
                _ownerResizeMode = null;
                _ownerIsHitTestVisible = false;
                _ownerFocusable = false;
                _progressWindowControl = null;
                _owner = null;
                _isVisible = false;
            }
        }
        public static void SetProgress(double progress, double maxProgress)
        {
            if (_progressWindowControl != null)
            {
                if (_progressWindowControl.Dispatcher.CheckAccess())
                {
                    _progressWindowControl.IsIndeterminate = false;
                    _progressWindowControl.Progress = progress;
                    _progressWindowControl.MaxProgress = maxProgress;
                }
                else
                {
                    _progressWindowControl.Dispatcher.Invoke(DispatcherPriority.Normal,
                        new ThreadStart(() =>
                        {
                            _progressWindowControl.IsIndeterminate = false;
                            _progressWindowControl.Progress = progress;
                            _progressWindowControl.MaxProgress = maxProgress;
                        }));
                }
            }
        }
        public static void SetIsIndeterminate(bool isIndeterminate)
        {
            if (_progressWindowControl != null)
            {
                if (_progressWindowControl.Dispatcher.CheckAccess())
                {
                    _progressWindowControl.IsIndeterminate = isIndeterminate;
                }
                else
                {
                    _progressWindowControl.Dispatcher.Invoke(DispatcherPriority.Normal,
                        new ThreadStart(() =>
                        {
                            _progressWindowControl.IsIndeterminate = isIndeterminate;
                        }));
                }
            }
        }
        public static void SetState(string state)
        {
            if (_progressWindowControl != null)
            {
                if (_progressWindowControl.Dispatcher.CheckAccess())
                {
                    _progressWindowControl.State = state;
                }
                else
                {
                    _progressWindowControl.Dispatcher.Invoke(DispatcherPriority.Normal,
                        new ThreadStart(() =>
                        {
                            _progressWindowControl.State = state;
                        }));
                }
            }
        }
        public static void SetIsCancelAllowed(bool isCancelAllowed, Action progressWindowCancel)
        {
            if (_progressWindowControl != null)
            {
                if (_progressWindowControl.Dispatcher.CheckAccess())
                {
                    _progressWindowControl.OnProgressWindowCancel = progressWindowCancel;
                    _progressWindowControl.uxCancelBtn.IsEnabled = isCancelAllowed;
                    _progressWindowControl.uxCancelBtn.Content = Strings.Cancel;
                }
                else
                {
                    _progressWindowControl.Dispatcher.Invoke(DispatcherPriority.Normal,
                        new ThreadStart(() =>
                        {
                            _progressWindowControl.OnProgressWindowCancel = progressWindowCancel;
                            _progressWindowControl.uxCancelBtn.IsEnabled = isCancelAllowed;
                            _progressWindowControl.uxCancelBtn.Content = Strings.Cancel;
                        }));
                }
            }
        }
    }
