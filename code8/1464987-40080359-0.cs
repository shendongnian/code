    public partial class AnimatedTextBlock : TextBlock
    {
        public static readonly RoutedEvent MyCustomEvent;
        static AnimatedTextBlock()
        { 
            MyCustomEvent = EventManager.RegisterRoutedEvent("MyCustomEvent", RoutingStrategy.Bubble, typeof(MyCustomHandler)
                , typeof(AnimatedTextBlock));
        }
        public AnimatedTextBlock()
        {
            InitializeComponent();            
        }
    }
    
    public delegate void MyCustomHandler();
    public static class EventHandlerExtension
    {
        public static void TriggerThisEvent(this RoutedEvent routedEvt, AnimatedTextBlock tb)
        {
            RoutedEventArgs args = new RoutedEventArgs(AnimatedTextBlock.MyCustomEvent, tb);
            tb.RaiseEvent(args);
        }
    }
