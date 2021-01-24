    public class KeyboardShortcutBehavior : Behavior<FrameworkElement>
    {
        private Window _parentWindow;
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(nameof(Command), typeof(ICommand),
            typeof(KeyboardShortcutBehavior), new FrameworkPropertyMetadata(null));
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public static readonly DependencyProperty ModifierKeyProperty =
            DependencyProperty.Register(nameof(ModifierKey), typeof(ModifierKeys),
            typeof(KeyboardShortcutBehavior), new FrameworkPropertyMetadata(ModifierKeys.None));
        public ModifierKeys ModifierKey
        {
            get { return (ModifierKeys)GetValue(ModifierKeyProperty); }
            set { SetValue(ModifierKeyProperty, value); }
        }
        public static readonly DependencyProperty KeyProperty =
            DependencyProperty.Register(nameof(Key), typeof(Key),
                typeof(KeyboardShortcutBehavior), new FrameworkPropertyMetadata(Key.None));
        public Key Key
        {
            get { return (Key)GetValue(KeyProperty); }
            set { SetValue(KeyProperty, value); }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Loaded += AssociatedObject_Loaded;
            AssociatedObject.Unloaded += AssociatedObject_Unloaded;
        }
        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            _parentWindow = Window.GetWindow(AssociatedObject);
            if(_parentWindow != null)
            {
                _parentWindow.PreviewKeyDown += ParentWindow_PreviewKeyDown;
            }
        }
        private void ParentWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(Command != null && ModifierKey != ModifierKeys.None && Key != Key.None && Keyboard.Modifiers == ModifierKey && e.Key == Key)
                Command.Execute(null);
        }
        private void AssociatedObject_Unloaded(object sender, RoutedEventArgs e)
        {
            if(_parentWindow != null)
            {
                _parentWindow.PreviewKeyDown -= ParentWindow_PreviewKeyDown;
            }
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Loaded -= AssociatedObject_Loaded;
            AssociatedObject.Unloaded -= AssociatedObject_Loaded;
        }
    }
