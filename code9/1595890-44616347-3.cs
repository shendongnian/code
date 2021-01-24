    public partial class FuffaControl : UserControl
    {
        public FuffaControl()
        {
            InitializeComponent();
            AddHandler(FuffaEvent, new RoutedEventHandler(OnFuffaEvent));
        }
        public static readonly RoutedEvent FuffaEvent = EventManager.RegisterRoutedEvent(
            "Fuffa", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FuffaControl));
        public event RoutedEventHandler Fuffa
        {
            add { AddHandler(FuffaEvent, value); }
            remove { RemoveHandler(FuffaEvent, value); }
        }
        public void RaiseFuffaEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(FuffaEvent);
            RaiseEvent(newEventArgs);
        }
        private void OnFuffaEvent(object sender, RoutedEventArgs e)
        {
        }
    }
