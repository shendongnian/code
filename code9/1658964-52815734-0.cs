    public class KeyUpToCommandBehaviour : Behavior<UIElement>
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command", typeof(ICommand), typeof(KeyUpToCommandBehaviour), new PropertyMetadata(default(ICommand)));
        public ICommand Command
        {
            get { return (ICommand) GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public static readonly DependencyProperty KeyProperty = DependencyProperty.Register(
            "Key", typeof(Key), typeof(KeyUpToCommandBehaviour), new PropertyMetadata(default(Key)));
        private RoutedEventHandler _routedEventHandler;
        public Key Key
        {
            get { return (Key) GetValue(KeyProperty); }
            set { SetValue(KeyProperty, value); }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            _routedEventHandler = AssociatedObject_KeyUp;
            AssociatedObject.AddHandler(UIElement.KeyUpEvent, _routedEventHandler, true);
        }
        void AssociatedObject_KeyUp(object sender, RoutedEventArgs e)
        {
            var keyArgs = e as KeyEventArgs;
            if (keyArgs == null)
                return;
            if(keyArgs.Key == Key)
                Command?.Execute(null);
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.RemoveHandler(UIElement.KeyUpEvent, _routedEventHandler);
        }
    }
