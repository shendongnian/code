    public static class EventHandlerExtension
    {
        public static void TriggerThisEvent(this RoutedEvent routedEvt, FrameworkElement felem)
        {
            RoutedEventArgs args = new RoutedEventArgs(routedEvt, felem);
            felem.RaiseEvent(args);
        }
    }
