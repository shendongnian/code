    public partial class FuffaControl : UserControl
    {
        public FuffaControl()
        {
            InitializeComponent();
        }
        public static readonly RoutedEvent FuffaEvent = EventManager.RegisterRoutedEvent(
            "Fuffa", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FuffaControl));
        public event RoutedEventHandler FuffaEventHandler
        {
            add { AddHandler(FuffaEvent, value); }
            remove { RemoveHandler(FuffaEvent, value); }
        }
        public void RaiseFuffaEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(FuffaEvent);
            RaiseEvent(newEventArgs);
            OnFuffaEvent(this, newEventArgs);
        }
        private void OnFuffaEvent(object sender, RoutedEventArgs e)
        {
        }
    }
