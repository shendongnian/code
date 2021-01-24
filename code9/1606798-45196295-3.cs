    // ViewModel event args 
    public class MyEventArgs : EventArgs
    {
        public object Param { get; set; }
    }
    // Interim args to hold params during event transfer    
    public class TransferEventArgs : RoutedEventArgs
    {
        public TransferEventArgs(RoutedEvent e) : base(e) { }
        public object Param { get; set; }
    }
    // Base view model
    public class ViewModelBase
    {
        public event EventHandler<MyEventArgs> MyEvent;
        public void TransferClick()
        {
            MyEvent?.Invoke(this, new MyEventArgs { Param = DateTime.Now }); // to simulate the click at View
        }
    }
    // the attached behavior that does the magic binding
    public class EventMapper : DependencyObject
    {
        public static bool GetTransferEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(TransferEnabledProperty);
        }
        public static void SetTransferEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(TransferEnabledProperty, value);
        }
        public static readonly DependencyProperty TransferEnabledProperty =
            DependencyProperty.RegisterAttached("TransferEnabled",
            typeof(bool), typeof(EventMapper), new PropertyMetadata
            (false, new PropertyChangedCallback(OnTransferEnabledChanged)));
        private static void OnTransferEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            FrameworkElement uie = d as FrameworkElement;
            if (uie == null)
                return;
            EventHandler<MyEventArgs> myEventHandler = delegate (object sender, MyEventArgs e) {
                if (GetTransferEnabled(uie))
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    uie.RaiseEvent(new TransferEventArgs(EventMapper.OnTransferEvent)
                    {
                        Source = sender,
                        Param = e?.Param
                    }));
                }
            };
            uie.DataContextChanged += (object sender, DependencyPropertyChangedEventArgs e) =>
            {
                var oldVM = e.OldValue as ViewModelBase;
                var newVM = e.NewValue as ViewModelBase;
                if (oldVM != null)
                    oldVM.MyEvent -= myEventHandler;
                if (newVM != null)
                    newVM.MyEvent += myEventHandler;
            };
            var viewModel = uie.DataContext as ViewModelBase;
            if (viewModel != null)
                viewModel.MyEvent += myEventHandler;
        }
        public static readonly RoutedEvent OnTransferEvent =
            EventManager.RegisterRoutedEvent("OnTransfer",
                RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(EventMapper));
        public static void AddOnTransferHandler(DependencyObject d, RoutedEventHandler handler)
        {
            FrameworkElement uie = d as FrameworkElement;
            if (uie != null)
            {
                uie.AddHandler(OnTransferEvent, handler);
            }
        }
        public static void RemoveOnTransferHandler(DependencyObject d, RoutedEventHandler handler)
        {
            FrameworkElement uie = d as FrameworkElement;
            if (uie != null)
            {
                uie.RemoveHandler(OnTransferEvent, handler);
            }
        }
    }
