    public class EventCommandConverterBehavior : Behavior<FrameworkElement>
    {
        private Delegate eventHandler;
        private EventInfo oldEvent;
        // Event
        public string EventName { get { return (string)GetValue(EventNameProperty); } set { SetValue(EventNameProperty, value); } }
        public static readonly DependencyProperty EventNameProperty = DependencyProperty.Register("EventName", typeof(string), typeof(EventCommandConverterBehavior), new PropertyMetadata(null, OnEventChanged));
        // Command
        public ICommand Command { get { return (ICommand)GetValue(CommandProperty); } set { SetValue(CommandProperty, value); } }
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(EventCommandConverterBehavior), new PropertyMetadata(null));
        public string PropertyName { get { return (string)GetValue(PropertyNameProperty); } set { SetValue(PropertyNameProperty, value); } }
        public static readonly DependencyProperty PropertyNameProperty = DependencyProperty.Register("PropertyName", typeof(string), typeof(EventCommandConverterBehavior), new PropertyMetadata());
        private static void OnEventChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            var behavior = (EventCommandConverterBehavior)dependencyObject;
            if (behavior.AssociatedObject != null)
                behavior.AttachHandler((string)args.NewValue);
        }
        protected override void OnAttached()
        {
            AttachHandler(this.EventName);
        }
        private void AttachHandler(string eventName)
        {
            // detach old event
            if (this.oldEvent != null)
                this.oldEvent.RemoveEventHandler(this.AssociatedObject, this.eventHandler);
            // attach new event
            if (string.IsNullOrEmpty(eventName))
            {
                return;
            }
            var eventInfo = this.AssociatedObject.GetType().GetEvent(eventName);
            if (eventInfo != null)
            {
                var methodInfo = this.GetType()
                    .GetMethod("CommandExecuter", BindingFlags.Instance | BindingFlags.NonPublic);
                this.eventHandler = Delegate.CreateDelegate(eventInfo.EventHandlerType, this, methodInfo);
                eventInfo.AddEventHandler(this.AssociatedObject, this.eventHandler);
                this.oldEvent = eventInfo;
            }
            else
                throw new ArgumentException(string.Format("Type {0} does not contain event {1} definition.",
                    this.AssociatedObject.GetType().Name, eventName));
        }
        private void CommandExecuter(object sender, EventArgs e)
        {
            object parameter = null != PropertyName ? GetPropValue(sender, PropertyName) : e;
            if (this.Command != null)
            {
                if (this.Command.CanExecute(parameter))
                    this.Command.Execute(parameter);
            }
        }
        public static object GetPropValue(object src, string propName)
        {
            var propertyInfo = src.GetType().GetProperty(propName);
            return propertyInfo != null ? propertyInfo.GetValue(src, null) : null;
        }
    }
