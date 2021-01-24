    // ViewModel event args 
    public class MyEventArgs : EventArgs
    {
        public object Param { get; set; }
    }
    // Interim args to hold params during event transfer    
    public class InvokeEventArgs : RoutedEventArgs
    {
        public InvokeEventArgs(RoutedEvent e) : base(e) { }
        public object Param { get; set; }
    }    
    // Base view model
    public class ViewModelBase
    {
        public event EventHandler<MyEventArgs> MyEvent1;
        public event EventHandler<MyEventArgs> MyEvent2;
        public void TransferClick1()
        {
            MyEvent1?.Invoke(this, new MyEventArgs { Param = DateTime.Now }); // to simulate the click at View
        }
        public void TransferClick2()
        {
            MyEvent2?.Invoke(this, new MyEventArgs { Param = DateTime.Today.DayOfWeek }); // to simulate the click at View
        }
    }
    // the attached behavior that does the magic binding
    public class EventMapper : DependencyObject
    {
        public static string GetTrackEventName(DependencyObject obj)
        {
            return (string)obj.GetValue(TrackEventNameProperty);
        }
        public static void SetTrackEventName(DependencyObject obj, string value)
        {
            obj.SetValue(TrackEventNameProperty, value);
        }
        public static readonly DependencyProperty TrackEventNameProperty =
            DependencyProperty.RegisterAttached("TrackEventName",
                typeof(string), typeof(EventMapper), new PropertyMetadata
                (null, new PropertyChangedCallback(OnTrackEventNameChanged)));
        private static void OnTrackEventNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            FrameworkElement uie = d as FrameworkElement;
            if (uie == null)
                return;
            var eventName = GetTrackEventName(uie);
            if (string.IsNullOrWhiteSpace(eventName))
                return;
            EventHandler<MyEventArgs> vmEventTracker = delegate (object sender, MyEventArgs e) {
                Application.Current.Dispatcher.Invoke(() =>
                    uie.RaiseEvent(new InvokeEventArgs(EventMapper.OnInvokeEvent)
                    {
                        Source = sender,
                        Param = e?.Param
                    }));
            };
            uie.DataContextChanged += (object sender, DependencyPropertyChangedEventArgs e) =>
            {
                var oldVM = e.OldValue;
                var newVM = e.NewValue;
                if (oldVM != null)
                {
                    var eventInfo = oldVM.GetType().GetEvent(eventName);
                    eventInfo?.RemoveEventHandler(oldVM, vmEventTracker);
                }
                    
                if (newVM != null)
                {
                    var eventInfo = newVM.GetType().GetEvent(eventName);
                    eventInfo?.AddEventHandler(newVM, vmEventTracker);
                }
            };
            var viewModel = uie.DataContext;
            if (viewModel != null)
            {
                var eventInfo = viewModel.GetType().GetEvent(eventName);
                eventInfo?.AddEventHandler(viewModel, vmEventTracker);
            }
        }
        public static readonly RoutedEvent OnInvokeEvent =
            EventManager.RegisterRoutedEvent("OnInvoke",
                RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(EventMapper));
        public static void AddOnInvokeHandler(DependencyObject d, RoutedEventHandler handler)
        {
            FrameworkElement uie = d as FrameworkElement;
            if (uie != null)
            {
                uie.AddHandler(OnInvokeEvent, handler);
            }
        }
        public static void RemoveOnInvokeHandler(DependencyObject d, RoutedEventHandler handler)
        {
            FrameworkElement uie = d as FrameworkElement;
            if (uie != null)
            {
                uie.RemoveHandler(OnInvokeEvent, handler);
            }
        }
    }
